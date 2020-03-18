using System;
using System.Collections.Generic;
using System.Text;
using AccountsTestP.Domain.Queries;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Data.IRepositories;
using MediatR;
using System.Threading.Tasks;
using System.Linq;
using AccountsTestP.Domain.Models;
using AccountsTestP.Domain.Command;
using System.Threading;

namespace AccountsTestP.Service.Helper
{
    /// <summary>
    /// Класс методов для проведения корректировки по счетам
    /// </summary>
    public class PastDueDateAccountEntryHelper
    {
        private readonly IAccountsHistoryRepository _accountsHistoryRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMediator _mediator;
        private readonly BaseHelper _helper;
        private readonly CreateAccountHistoryHelper _createAccountEntryHelper;
        private readonly string _errorStatus = "Error";
        private readonly string _message = "Баланс одного из счетов при пересчете стал ниже нуля";
        /// <summary>
        /// Конструктор класса методов для проведения корректировки по счетам
        /// </summary>
        /// <param name="mediator">Сущность класса MediatR</param>
        /// <param name="accountsHistoryRepository">Объект типа класса работы с таблицей журнала проводок</param>
        /// <param name="accountRepository">Объект типа класса работы с таблицей счетов</param>
        public PastDueDateAccountEntryHelper(IMediator mediator, IAccountsHistoryRepository accountsHistoryRepository, IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _mediator = mediator;
            _accountsHistoryRepository = accountsHistoryRepository;
            _helper = new BaseHelper(_accountRepository);
            _createAccountEntryHelper = new CreateAccountHistoryHelper(_accountsHistoryRepository, _accountRepository);
        }


        /// <summary>
        /// Метод проведения корректирующей проводки в прошлое число
        /// </summary>
        /// <param name="sourceAccount">DTO счета с которого совершается проводка</param>
        /// <param name="destinationAccount">DTO счета на который совершается проводка</param>
        /// <param name="request">Сущность комманды создания счета</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        public async Task<ResponseBaseDto> TryRecalculateEntriesForTransfer(AccountDto sourceAccount,
                                       AccountDto destinationAccount,
                                       CreateTransferAccountCommand request,
                                       CancellationToken cancellationToken)
        {

            var sourceType = (ResponseOkDto<AccountTypeModel>)await _mediator.Send(new GetAccountTypeQuery(request.SourceAccountType));
            var destinationType = (ResponseOkDto<AccountTypeModel>)await _mediator.Send(new GetAccountTypeQuery(request.DestinationAccountType));
            var isSourceActive = sourceType.Result.IsActive;
            var isDestinatiomActive = destinationType.Result.IsActive;
            var accountsForUpdate = new List<AccountHistoryModel>();
            if (sourceAccount is null && destinationAccount is null)
            {
                return await _createAccountEntryHelper.CreateAccountHistoryTransferEntry(sourceAccount, destinationAccount,isSourceActive,isDestinatiomActive, request, cancellationToken);
            }
            else if (sourceAccount is null && destinationAccount is AccountDto)
            {
                
                if (!isSourceActive)
                   return _helper.FormMessageResponse(_errorStatus, _message);
                sourceAccount = _helper.InitiateAccount(request.SourceAccountNumber, request.SourceAccountType, isSourceActive);
                var accountEntryListTask = GetListOfAccountHistoryEntries(destinationAccount.Id, request.DueDate);
                var destinationAccountBalanceForEntry = await SetCurrentBalanceForEntry(accountEntryListTask, destinationAccount);
                bool hasNegativeAmountAccountEntries = false;
                if (accountEntryListTask.Result != null)
                {
                    var check = await IsCanNotUpdateEntry(sourceAccount.Id, destinationAccount.Id,isSourceActive,destinationAccount.IsActive, accountEntryListTask, request.DueDate, request.Amount);
                    hasNegativeAmountAccountEntries = check;
                }

                if (!hasNegativeAmountAccountEntries)
                    return await FormPastAccountEntryResponse(sourceAccount, destinationAccount, request, 0M , destinationAccountBalanceForEntry, false, true);
                return _helper.FormMessageResponse(_errorStatus, _message);
            }
            else if (sourceAccount is AccountDto && destinationAccount is null) 
            {
                if(isDestinatiomActive)
                    return _helper.FormMessageResponse(_errorStatus, _message);
                destinationAccount = _helper.InitiateAccount(request.DestinationAccountNumber, request.DestinationAccountType, isDestinatiomActive);
                var accountEntryListTask = GetListOfAccountHistoryEntries(sourceAccount.Id, request.DueDate);
                var sourceAccountBalanceForEntry = await SetCurrentBalanceForEntry(accountEntryListTask, sourceAccount);
                bool hasNegativeAmmountAccountEntries = false;
                if (accountEntryListTask.Result == null) 
                    hasNegativeAmmountAccountEntries = _helper.ValidateAmmount(sourceAccount.Balance, request.Amount);
                else 
                {
                    var check = await IsCanNotUpdateEntry(sourceAccount.Id, destinationAccount.Id,isSourceActive,isDestinatiomActive, accountEntryListTask, request.DueDate, request.Amount);
                    hasNegativeAmmountAccountEntries = check;
                }

                if (!hasNegativeAmmountAccountEntries)
                    return await FormPastAccountEntryResponse(sourceAccount, destinationAccount, request,sourceAccountBalanceForEntry,0M, true, false);
                return _helper.FormMessageResponse(_errorStatus, _message);
            }
            else 
            {
                var accountEntryListTask = GetListOfAccountHistoryEntries(sourceAccount.Id, destinationAccount.Id, request.DueDate);
                var destinationAccountBalanceForEntry = await SetCurrentBalanceForEntry(accountEntryListTask, destinationAccount);
                var sourceAccountBalanceForEntry = await SetCurrentBalanceForEntry(accountEntryListTask, sourceAccount);
                bool hasNegativeAmmountAccountEntries=false;
                if (accountEntryListTask.Result == null) 
                {
                    if (!sourceAccount.IsActive)
                        hasNegativeAmmountAccountEntries = _helper.ValidateAmmount(sourceAccount.Balance, request.Amount);
                    if (destinationAccount.IsActive)
                        hasNegativeAmmountAccountEntries = _helper.ValidateAmmount(destinationAccount.Balance, request.Amount);
                }
                    
                else
                {
                    var check= await IsCanNotUpdateEntry(sourceAccount.Id, destinationAccount.Id,sourceAccount.IsActive,destinationAccount.IsActive, accountEntryListTask, request.DueDate, request.Amount);
                    hasNegativeAmmountAccountEntries = check;
                }
                if (!hasNegativeAmmountAccountEntries)
                    return await FormPastAccountEntryResponse(sourceAccount, destinationAccount, request,sourceAccountBalanceForEntry,destinationAccountBalanceForEntry, true, true);
                return _helper.FormMessageResponse(_errorStatus, _message);
            }

            
        }
        /// <summary>
        /// Проверка возможности проведения корректировки проводки
        /// </summary>
        /// <param name="sourceAccount">Счет дебета</param>
        /// <param name="destinationAccount">Счет кредита</param>
        /// <param name="request"> Объект содержащий поля запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        private async Task<bool> CheckAccountEntryList(AccountDto sourceAccount,
                                       AccountDto destinationAccount,
                                       CreateTransferAccountCommand request,
                                       CancellationToken cancellationToken) 
        {
            Task<List<AccountHistoryDto>> accountEntryListTask;
            if (sourceAccount is null)
            {
                var sourceType = (ResponseOkDto<AccountTypeModel>)await _mediator.Send(new GetAccountTypeQuery(request.SourceAccountType));
                var isSourceActive = sourceType.Result.IsActive;
                if (!isSourceActive)
                    return true;

                sourceAccount = _helper.InitiateAccount(request.SourceAccountNumber, request.SourceAccountType, isSourceActive);
                accountEntryListTask = GetListOfAccountHistoryEntries(destinationAccount.Id, request.DueDate);

                if (accountEntryListTask.Result is null)
                    return _helper.ValidateAmmount(destinationAccount.Balance, request.Amount);
            }

            else if (destinationAccount is null)
            {
                var destinationType = (ResponseOkDto<AccountTypeModel>)await _mediator.Send(new GetAccountTypeQuery(request.SourceAccountType));
                var isDestinationActive = destinationType.Result.IsActive;
                if (!isDestinationActive)
                    return true;

                sourceAccount = _helper.InitiateAccount(request.SourceAccountNumber, request.DestinationAccountType, isDestinationActive);
                accountEntryListTask = GetListOfAccountHistoryEntries(sourceAccount.Id, request.DueDate);

                if (accountEntryListTask.Result is null)
                    return _helper.ValidateAmmount(destinationAccount.Balance, request.Amount);
            }
            else
            {
                accountEntryListTask = GetListOfAccountHistoryEntries(sourceAccount.Id, destinationAccount.Id, request.DueDate);
                var destinationAccountBalanceForEntry = await SetCurrentBalanceForEntry(accountEntryListTask, destinationAccount);
                var sourceAccountBalanceForEntry = await SetCurrentBalanceForEntry(accountEntryListTask, sourceAccount);
                if (accountEntryListTask.Result == null) 
                {
                    if(!sourceAccount.IsActive)
                       return _helper.ValidateAmmount(sourceAccount.Balance, request.Amount);
                    if (destinationAccount.IsActive)
                        return _helper.ValidateAmmount(destinationAccount.Balance, request.Amount);
                }
                    

            }     
            
            return await IsCanNotUpdateEntry(sourceAccount.Id, destinationAccount.Id, sourceAccount.IsActive, destinationAccount.IsActive, accountEntryListTask, request.DueDate, request.Amount);
        }
        /// <summary>
        /// Метод проведения корректирующей проводки в прошлое число
        /// </summary>
        /// <param name="account">DTO счета </param>
        /// <param name="request">Сущность комманды создания счета</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        public async Task<ResponseBaseDto> TryRecalculateEntriesForSolo(AccountDto account,
                                               CreateAccountHistoryEntryCommand request,
                                               CancellationToken cancellationToken) 
        {
            
            if (account == null)
            {
                return await _createAccountEntryHelper.CreateAccountHistorySoloEntry(account, request, cancellationToken);

            }
            var hasNegativeEntriesForAccount = false;
            var accountEntryListTask = GetListOfAccountHistoryEntries(account.Id, request.DueDate);
            var currentBalance = await SetCurrentBalanceForEntry(accountEntryListTask, account);

            var accountEntryListOut = new List<AccountHistoryModel>();
            
            if (request.IsTopUp) 
            {
                if (accountEntryListTask.Result != null) 
                {
                    var check = await IsCanNotUpdateEntry(Guid.Empty, account.Id,false,false, accountEntryListTask, request.DueDate, request.Amount);
                    hasNegativeEntriesForAccount = check; 
                }
            }
            else 
            {
                if (accountEntryListTask.Result is null) 
                {
                    hasNegativeEntriesForAccount = _helper.ValidateAmmount(account.Balance, request.Amount);
                }
                else 
                {
                    var check = await IsCanNotUpdateEntry(account.Id, Guid.Empty,false,false, accountEntryListTask, request.DueDate, request.Amount);
                    hasNegativeEntriesForAccount = check;
                }
               
            }
            
            if (!hasNegativeEntriesForAccount) 
                return await FormPastAccountEntryFotResponse(account,request.OperationId,request.Amount, currentBalance,request.IsTopUp, request.DueDate,request.Description);

            return _helper.FormMessageResponse(_errorStatus, _message);
        }
        /// <summary>
        /// Получение баланса счета на дату влияния на проводку. Если не было ни одной проводки с даты влияния на счет корректирующей проводки до текущего момента, то берется текущий баланс
        /// </summary>
        /// <param name="accountEntryList">Список записей в журнале проводок на которые влияет корректирующая проводка</param>
        /// <param name="account">DTO счета</param>
        /// <returns>Баланс на дату</returns>
        private async Task<decimal> SetCurrentBalanceForEntry(Task<List<AccountHistoryDto>> accountEntryList, AccountDto account)  
        {
            var accountEntries = await accountEntryList;

            if (accountEntries is null)
                return account.Balance;
            else 
            {
                accountEntries = accountEntries.OrderBy(x => x.DueDateTime).ToList();
                var currentEntry = accountEntries.Where(x => x.SourceAccountId == account.Id || x.DestinationAccounId == account.Id).FirstOrDefault();
                if (currentEntry == null) 
                    return account.Balance;

                return GetBalance(currentEntry, account.Id, account.IsActive);
            }

                
        }
        /// <summary>
        /// Расчет баланса на дату совершения корректирующей проводки. 
        /// </summary>
        /// <param name="entry">Запись в журнале проводок </param>
        /// <param name="accountId">Id счета</param>
        /// <param name = "isActive">Флаг апризнака активности счета </param>
        /// <returns>Изменный баланс для записи в журнале проводок</returns>
        private decimal GetBalance(AccountHistoryDto entry,Guid accountId, bool isActive) 
        {
            var balance = new decimal();
            if (accountId == entry.DestinationAccounId && isActive == false)
                balance = _helper.WithDrawlBalance(entry.DestinationBalance, entry.Amount);
            else if (accountId == entry.DestinationAccounId && isActive == true)
                balance = _helper.TopUpBalance(entry.DestinationBalance, entry.Amount);
            else if (accountId == entry.SourceAccountId && isActive == false)
                balance = _helper.WithDrawlBalance(entry.SourceBalance, entry.Amount);
            else if (accountId == entry.SourceAccountId && isActive == true)
                balance = _helper.WithDrawlBalance(entry.SourceBalance, entry.Amount);
            return balance;
        }

        /// <summary>
        /// Проверка возможности проведения корректирующей проводки
        /// </summary>
        /// <param name="sourceAccountId">Id счета с которого совершается проводка</param>
        /// <param name="destinationAccountId">Id счета на который совершается проводка</param>
        /// <param name="accountEntryList">Список записей в журнале проводок на которые влияет корректирующая проводка</param>
        /// <param name="dueDate">Время влияния проводки</param>
        /// <param name="amount">Сумма проводки</param>
        /// <returns>Возвращает true в случае невозможности проведения проводки, false - в случае возможности проведения проводки и  спсок DTO записей журнала провдок, которые затрагивает корректирующая проводка</returns>
        private async Task<bool> IsCanNotUpdateEntry(Guid sourceAccountId, 
                                                                                             Guid destinationAccountId,
                                                                                             bool isSourceActive,
                                                                                             bool isDestinationActive,
                                                                                             Task<List<AccountHistoryDto>> accountEntryList, 
                                                                                             DateTimeOffset dueDate, 
                                                                                             decimal amount)
        {
            var entryList = new List<AccountHistoryModel>();

            await foreach (var entry in PastEntriesToInfluenceBalance(sourceAccountId,destinationAccountId,isSourceActive, isDestinationActive, accountEntryList,  dueDate, amount))
            {
                if (entry == null)
                    return true;
                else
                {
                    var accountEntry = new AccountHistoryModel(entry.Id, entry.DestinationAccounId, entry.SourceAccountId, entry.Amount, entry.SourceBalance, entry.DestinationBalance, entry.DueDateTime, entry.Description, entry.OperationId);
                    entryList.Add(accountEntry);
                }
            }
            if (entryList.Count != 0)
            {
                _accountsHistoryRepository.UpdateAccountsEntries(entryList);
                await _accountsHistoryRepository.SaveChangesAsync();
            } 
            return false;
        }
        /// <summary>
        /// Получить список записей в журнале проводок, которые затрагивают корректирующая проводка. 
        /// </summary>
        /// <param name="accountId">Id счета</param>
        /// <param name="dueDate">Дата влияния на проводку</param>
        /// <returns>Список записей в журнале проводок, которые затрагивают корректирующая проводка </returns>
        private async Task<List<AccountHistoryDto>> GetListOfAccountHistoryEntries(Guid accountId, 
                                                                                   DateTimeOffset dueDate) => await _mediator.Send(new GetSingleAccountHistoryFromDateQuery(accountId, dueDate));
        /// <summary>
        /// Получить список записей в журнале проводок, которые затрагивают корректирующая проводка.
        /// </summary>
        /// <param name="sourceAccountId">Id счета с которого совершается проводка</param>
        /// <param name="destinationAccountId">Id счета на который совершается проводка</param>
        /// <param name="dueDate">Дата влияния на проводку</param>
        /// <returns>Список записей в журнале проводок, которые затрагивают корректирующая проводка</returns>
        private async Task<List<AccountHistoryDto>> GetListOfAccountHistoryEntries(Guid sourceAccountId, 
                                                                                   Guid destinationAccountId, 
                                                                                   DateTimeOffset dueDate) => await _mediator.Send(new GetAccountHistoryFromDateQuery(sourceAccountId, destinationAccountId, dueDate));
        /// <summary>
        /// Ассинхроный итератор проводящий изменение баланса в записях журнала на которых влияет корректирующая проводка  
        /// </summary>
        /// <param name="sourceAccountId">Id счета с которого совершается проводка</param>
        /// <param name="destinationAccountId">Id счета на который совершается проводка</param>
        /// <param name="isSourceActive">Флаг признака активного типа для счета дебета</param>
        /// <param name="isDestinationActive">Флаг признака активного типа для счета кредита</param>
        /// <param name="accountEntries">Список записей в журнале проводок</param>
        /// <param name="dueDate">Дата влияния на проводку</param>
        /// <param name="requestedAmount">Сумма влияния на записи</param>
        /// <returns>Записи из спсика проводок</returns>
        private async IAsyncEnumerable<AccountHistoryDto> PastEntriesToInfluenceBalance(Guid sourceAccountId,
                                                                                        Guid destinationAccountId,
                                                                                        bool isSourceActive,
                                                                                        bool isDestinationActive,
                                                                                        Task<List<AccountHistoryDto>> accountEntries, 
                                                                                        DateTimeOffset dueDate, 
                                                                                        decimal requestedAmount)
        {
            var proceedingEntries = await accountEntries;
            var iterator = proceedingEntries.GetEnumerator();
            while (iterator.MoveNext())
            {
                if (sourceAccountId == iterator.Current.SourceAccountId && isSourceActive == false && sourceAccountId != Guid.Empty)
                {
                    if (_helper.ValidateAmmount(iterator.Current.SourceBalance, requestedAmount))
                    {
                        yield return null;
                        break;
                    }
                }
                if (sourceAccountId == iterator.Current.DestinationAccounId &&isSourceActive==false && sourceAccountId != Guid.Empty)
                {
                    if (_helper.ValidateAmmount(iterator.Current.DestinationBalance, requestedAmount))
                    {
                        yield return null;
                        break;
                    }
                }
                if (destinationAccountId == iterator.Current.SourceAccountId && isDestinationActive == true && destinationAccountId != Guid.Empty)
                {
                    if (_helper.ValidateAmmount(iterator.Current.SourceBalance, requestedAmount))
                    {
                        yield return null;
                        break;
                    }
                }
                if (destinationAccountId == iterator.Current.DestinationAccounId && isDestinationActive == true && destinationAccountId != Guid.Empty)
                {
                    if (_helper.ValidateAmmount(iterator.Current.DestinationBalance, requestedAmount))
                    {
                        yield return null;
                        break;
                    }
                }
                yield return UpdateEntry(sourceAccountId, destinationAccountId, isSourceActive,isDestinationActive,requestedAmount, iterator.Current);
            }

        }


        /// <summary>
        /// Метод изменения баланса счета в записи журнала изменений 
        /// </summary>
        /// <param name="sourceAccountId">Id счета с которого совершается проводка</param>
        /// <param name="destinationAccountId">Id счета на который совершается проводка</param>
        /// <param name="requestedAmount">Сумма запрашиваемого изменения</param>
        /// <param name="isSourceActive">Флаг признака активного типа для счета дебета</param>
        /// <param name="isDestinationActive">Флаг признака активного типа для счета кредита</param>
        /// <param name="entry">Запись в журнале проводок на которое действует изменения </param>
        /// <returns>Возвращает измененную запись в журнале проводок</returns>
        private AccountHistoryDto UpdateEntry(Guid sourceAccountId,
                                             Guid destinationAccountId,
                                             bool isSourceActive,
                                             bool isDestinationActive,
                                             decimal requestedAmount, 
                                             AccountHistoryDto entry) 
        {

            if (sourceAccountId == entry.SourceAccountId && isSourceActive == false && sourceAccountId != Guid.Empty)
                entry.SourceBalance = _helper.WithDrawlBalance(entry.SourceBalance, requestedAmount);

            else if (sourceAccountId == entry.DestinationAccounId && isSourceActive == false && sourceAccountId != Guid.Empty)
                entry.DestinationBalance = _helper.WithDrawlBalance(entry.DestinationBalance, requestedAmount);

            else if (sourceAccountId == entry.SourceAccountId && isSourceActive == true && sourceAccountId != Guid.Empty)
                entry.SourceBalance = _helper.TopUpBalance(entry.SourceBalance, requestedAmount);

            else if (sourceAccountId == entry.DestinationAccounId && isSourceActive == true && sourceAccountId != Guid.Empty)
                entry.DestinationBalance = _helper.TopUpBalance(entry.DestinationBalance, requestedAmount);




            if (destinationAccountId == entry.SourceAccountId &&isDestinationActive == false &&destinationAccountId !=Guid.Empty)
                entry.SourceBalance = _helper.TopUpBalance(entry.SourceBalance, requestedAmount);

            else if(destinationAccountId == entry.DestinationAccounId &&isDestinationActive == false && destinationAccountId != Guid.Empty)
                entry.DestinationBalance = _helper.TopUpBalance(entry.DestinationBalance, requestedAmount);

            else if (destinationAccountId == entry.SourceAccountId && isDestinationActive == true && destinationAccountId != Guid.Empty)
                entry.SourceBalance = _helper.WithDrawlBalance(entry.SourceBalance, requestedAmount);

            else if (destinationAccountId == entry.DestinationAccounId && isDestinationActive == true && destinationAccountId != Guid.Empty)
                entry.DestinationBalance = _helper.WithDrawlBalance(entry.DestinationBalance, requestedAmount);

            return entry;
        }

        /// <summary>
        /// Создание записи корректирующей проводки в журнал проводок 
        /// </summary>
        /// <param name="account">DTO счета</param>
        /// <param name="operationId">Id операции</param>
        /// <param name="amount">Сумма вносимого изменения</param>
        /// <param name="currentBalance">Баланс счета на дату изменения</param>
        /// <param name="isTopUp">Проверка на увеличение или уменьшение баланса</param>
        /// <param name="dueDate">Дата влияния на проводку</param>
        /// <param name="description">Описание проводки</param>
        /// <returns>Ответ для внешней системы. При успешном завершении возвращает сущность ResponseOkDto с id счета и скорректированным балансом </returns>
        private async Task<ResponseBaseDto> FormPastAccountEntryFotResponse(AccountDto account,
                                                                   Guid operationId,
                                                                   decimal amount,
                                                                   decimal currentBalance,
                                                                   bool isTopUp,
                                                                   DateTimeOffset dueDate,
                                                                   string description)
        {

            var helperListForUpdates = new List<AccountModel>();
            var balance = new decimal();
            AccountHistoryModel entry;
            if (isTopUp)
            {
                balance = _helper.TopUpBalance(currentBalance, amount);
                account.Balance = _helper.TopUpBalance(account.Balance, amount);
            }
            else
            {
                if (_helper.ValidateAmmount(currentBalance, amount))
                    return _helper.FormMessageResponse(_errorStatus, _message);
                else 
                {
                    balance = _helper.WithDrawlBalance(currentBalance, amount);
                    account.Balance = _helper.WithDrawlBalance(account.Balance, amount);
                }
            }
  
            helperListForUpdates.Add (_helper.entryForUpdate(account, account.Balance));
            if (isTopUp)
                entry = new AccountHistoryModel(Guid.Empty, account.Id, amount, balance, dueDate, operationId, description);
            else
                entry = new AccountHistoryModel(account.Id, amount, balance, dueDate, description, operationId);

            await _accountsHistoryRepository.AddEntry(entry);
            _helper.UpdateAccount(helperListForUpdates);
            if (await _accountsHistoryRepository.SaveChangesAsync() == 0)
                throw new ApplicationException();


            var result = new AccountTransferDto
            {
                AccountId = account.Id,
                CurrentBalance = balance
            };
            return _helper.FormResponseForCreateEntrySolo(result);
        }
        /// <summary>
        /// Создание записи корректирующей проводки в журнал проводок 
        /// </summary>
        /// <param name="sourceAccount">DTO счета с которого совершается проводка</param>
        /// <param name="destinationAccount">DTO счета на который совершается проводка</param>
        /// <param name="request">Сущность комманды создания записи в журнале проводки</param>
        /// <param name="sourceAccountBalanceForEntry">Баланс счета списания для записи в журнале проводок </param>
        /// <param name="destinationAccountBalanceForEntry">Баланс счета начисления для записи в журнале проводок </param>
        /// <param name="sourceAccountIsPresent">Флаг наличия счета с которого совершается проводка</param>
        /// <param name="destinationAccountIsPresent">Флаг наличия счета на который совершается проводка</param>
        /// <returns>Ответ для внешней системы. При успешном завершении возвращает сущность ResponseOkDto с id счета и скорректированным балансом</returns>
        private async Task<ResponseBaseDto> FormPastAccountEntryResponse(AccountDto sourceAccount,
                                                                  AccountDto destinationAccount,
                                                                  CreateTransferAccountCommand request,
                                                                  decimal sourceAccountBalanceForEntry,
                                                                  decimal destinationAccountBalanceForEntry,
                                                                  bool sourceAccountIsPresent,
                                                                  bool destinationAccountIsPresent)
        {
            var sourceBalance = new decimal();
            var destinationBalance = new decimal();
            var sourceBalanceForAccount = new decimal();
            var destinationBalanceForAccount = new decimal();
            var helperListForUpdates = new List<AccountModel>();
            if (!sourceAccount.IsActive)
            {
                if (_helper.ValidateAmmount(sourceAccountBalanceForEntry, request.Amount))
                    return _helper.FormMessageResponse(_errorStatus, _message);
                else
                {
                    sourceBalance = _helper.WithDrawlBalance(sourceAccountBalanceForEntry, request.Amount);
                    sourceBalanceForAccount = _helper.WithDrawlBalance(sourceAccount.Balance, request.Amount);
                }
            }
            else 
            {
                sourceBalance = _helper.TopUpBalance(sourceAccountBalanceForEntry, request.Amount);
                sourceBalanceForAccount = _helper.TopUpBalance(sourceAccount.Balance, request.Amount);
            }
            
                

            if (sourceAccountIsPresent)
                helperListForUpdates.Add(_helper.entryForUpdate(sourceAccount, sourceBalanceForAccount));
            else
                sourceAccount.Id = await _helper.SaveAccount(sourceAccount, sourceBalance);


            if (!destinationAccount.IsActive) 
            {
                destinationBalance = _helper.TopUpBalance(destinationAccountBalanceForEntry, request.Amount);
                destinationBalanceForAccount = _helper.TopUpBalance(destinationAccount.Balance, request.Amount);
                
            }
            else 
            {
                if(_helper.ValidateAmmount(destinationAccountBalanceForEntry, request.Amount))
                    return _helper.FormMessageResponse(_errorStatus, _message);
                else
                {
                    destinationBalance = _helper.WithDrawlBalance(destinationAccountBalanceForEntry, request.Amount);
                    destinationBalanceForAccount = _helper.WithDrawlBalance(destinationAccount.Balance, request.Amount);
                }
            }

            if (destinationAccountIsPresent)
                helperListForUpdates.Add(_helper.entryForUpdate(destinationAccount, destinationBalanceForAccount));
            else
                destinationAccount.Id = await _helper.SaveAccount(destinationAccount, destinationBalance);

            var entry = new AccountHistoryModel(destinationAccount.Id, sourceAccount.Id, request.Amount, sourceBalance, destinationBalance, request.DueDate, request.Description, request.OperationId);
            await _accountsHistoryRepository.AddEntry(entry);

            if (helperListForUpdates.Count != 0)
                _accountRepository.Update(helperListForUpdates);

            if (await _accountsHistoryRepository.SaveChangesAsync() == 0)
                throw new ApplicationException();


            var result = new TransactionDto
            {
                DestinationAccountId = destinationAccount.Id,
                SourceAccountId = sourceAccount.Id,

            };
            return _helper.FormResponseForCreateEntryTransaction(result);
        }
    }

   
}
