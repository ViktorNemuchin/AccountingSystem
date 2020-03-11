using AccountsTestP.Data.IRepositories;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountsTestP.Service.Helper
{
    /// <summary>
    /// Класс вспомогательных методов для работы со счетами
    /// </summary>
    public class AccountHistoryHelper
    {
        private readonly IAccountsHistoryRepository _accountsHistoryRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly BaseHelper _helper;
        private readonly string _errorStatus = "Error";
        private readonly string _message = "Баланс одного из счетов при пересчете стал ниже нуля";


        /// <summary>
        /// Конструктор класса методов для работы со счетами
        /// </summary>
        /// <param name="accountRepository">Объект типа класса работы с таблицей счетов</param>
        /// <param name="accountsHistoryRepository">Объект типа класса работы с таблицей журнала проводок</param>
        public AccountHistoryHelper(IAccountRepository accountRepository, IAccountsHistoryRepository accountsHistoryRepository)
        {
            _accountsHistoryRepository = accountsHistoryRepository;
            _accountRepository = accountRepository;
            _helper = new BaseHelper(_accountRepository);

        }

        /// <summary>
        /// Добавление записи об изменении счета
        /// </summary>
        /// <param name="account">DTO счета</param>
        /// <param name="operationId">Id операции</param>
        /// <param name="amount">Сумма изменения по счету</param>
        /// <param name="isTopUp">Проверка действмя</param>
        /// <param name="dueDate">Дата влияния на счет</param>
        /// <param name="description">Описание</param>
        /// <param name="accountPresent">Нужно ли создавать счет</param>
        /// <returns></returns>
        public async Task<ResponseBaseDto> FormAccountEntryResponse(AccountDto account,
                                                                    Guid operationId, 
                                                                    decimal amount, 
                                                                    bool isTopUp, 
                                                                    DateTimeOffset dueDate,
                                                                    string description, 
                                                                    bool accountPresent)
        {
            var initialBalance = account.Balance;   
            var balance = new decimal();
            AccountHistoryModel entry;
            if (isTopUp)
            {
                balance = _helper.TopUpBalance(initialBalance, amount);      
            }
            else
            {
                if (_helper.ValidateAmmount(initialBalance, amount))
                    return _helper.FormMessageResponse(_errorStatus, _message);
                else
                    balance = _helper.WithDrawlBalance(initialBalance, amount);
            }
                
            
            if (accountPresent)
                _helper.UpdateAccount(account, balance);
            else
                account.Id = await _helper.SaveAccount(account, balance);
            if (isTopUp) 
                entry = new AccountHistoryModel(Guid.Empty, account.Id, amount, balance, dueDate, operationId, description);
            else
                entry = new AccountHistoryModel(account.Id, amount, balance, dueDate,description, operationId);

            await _accountsHistoryRepository.AddEntry(entry);

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
        /// Добавление записи об изменении счета
        /// </summary>
        /// <param name="sourceAccount">DTO счета с которого совершается проводка</param>
        /// <param name="destinationAccount">DTO счета с на который совершается проводка</param>
        /// <param name="operationId">Id операции</param>
        /// <param name="amount">Сумма проводки </param>
        /// <param name="dueDateDate">Дата влия ния на проводку</param>
        /// <param name="description">Описание проводки</param>
        /// <param name="isSourcePresent">Присутствует ли счет с которго совершается проводка</param>
        /// <param name="isDestinationPresent">Присутсвует ли счет на который совершается проводка</param>
        /// <returns></returns>
        public async Task<ResponseBaseDto> FormAccountEntryResponse(AccountDto sourceAccount,
                                                                   AccountDto destinationAccount,
                                                                   Guid operationId, 
                                                                   decimal amount, 
                                                                   DateTimeOffset dueDate, 
                                                                   string description, 
                                                                   bool isSourcePresent, 
                                                                   bool isDestinationPresent)
        {
            var emptyAccount = "00000000000000000000";
            var initialSourceBalance = sourceAccount.Balance;
            var initialDestinationBalance = destinationAccount.Balance;
            var sourceBalance = new decimal();
            var destinationBalance = new decimal();
            if (sourceAccount.AccountNumber != emptyAccount) 
            {
                if (_helper.ValidateAmmount(initialSourceBalance, amount))
                    return _helper.FormMessageResponse(_errorStatus, _message);
                else
                    sourceBalance = _helper.WithDrawlBalance(initialSourceBalance, amount);

                if (isSourcePresent)
                    _helper.UpdateAccount(sourceAccount, sourceBalance);
                else
                    sourceAccount.Id = await _helper.SaveAccount(sourceAccount, sourceBalance);
            }
            
                
            if (destinationAccount.AccountNumber != emptyAccount) 
            {
                destinationBalance = _helper.TopUpBalance(initialDestinationBalance, amount);
                if (isDestinationPresent)
                    _helper.UpdateAccount(destinationAccount, destinationBalance);
                else
                    destinationAccount.Id = await _helper.SaveAccount(destinationAccount, destinationBalance);
            }



            var entry = new AccountHistoryModel(destinationAccount.Id, sourceAccount.Id, amount, sourceBalance, destinationBalance, dueDate, description, operationId);
            await _accountsHistoryRepository.AddEntry(entry);

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
