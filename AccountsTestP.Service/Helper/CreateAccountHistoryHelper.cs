using AccountsTestP.Data.IRepositories;
using AccountsTestP.Domain.Command;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AccountsTestP.Service.Helper
{
    /// <summary>
    /// Класс вспомогательных методов для создания записи в журнале проводок 
    /// </summary>
    public class CreateAccountHistoryHelper
    {
        private readonly AccountHistoryHelper _helper;
        private readonly IAccountsHistoryRepository _accountsHistoryRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly BaseHelper _baseHelper;

        /// <summary>
        /// Конструктор класса вспомогательгных методов для создания записи в журнале проводок
        /// </summary>
        /// <param name="accountsHistoryRepository">Объект типа класса работы с таблицей журнала проводок</param>
        /// <param name="accountRepository">Объект типа класса работы с таблицей счетов</param>
        public CreateAccountHistoryHelper(IAccountsHistoryRepository accountsHistoryRepository, IAccountRepository accountRepository) 
        {
            _accountRepository = accountRepository;
            _accountsHistoryRepository = accountsHistoryRepository;
            _helper = new AccountHistoryHelper(_accountRepository, _accountsHistoryRepository);
            _baseHelper = new BaseHelper(_accountRepository);
        }

        /// <summary>
        /// Созлание записи в журнале проводок
        /// </summary>
        /// <param name="account">DTO счета</param>
        /// <param name="request">Сущность комманды создания записи в журнале проводки</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        public async Task<ResponseBaseDto> CreateAccountHistorySoloEntry(AccountDto account,
                                                CreateAccountHistoryEntryCommand request, 
                                                CancellationToken  cancellationToken) 
        {
            if (account == null)
            {

                var createdAccount = _baseHelper.InitiateAccount(request.AccountNumber, request.AccountType, false);
                return await _helper.FormAccountEntryResponse(createdAccount, request.OperationId, request.Amount, request.IsTopUp, request.DueDate, request.Description, false);
            }

            return await _helper.FormAccountEntryResponse(account, request.OperationId, request.Amount, request.IsTopUp, request.DueDate, request.Description, true);
        }
        /// <summary>
        /// Созлание записи в журнале проводок
        /// </summary>
        /// <param name="sourceAccount">DTO счета с которого совершается проводка</param>
        /// <param name="destinationAccount">DTO счета на который совершается проводка</param>
        /// <param name="isActiceSource">Флаг признака активного типа для счета дебета</param>
        /// <param name="isActiveDestination">Флаг признака активного типа для счета кредита</param>
        /// <param name="request">Сущность комманды создания записи в журнале проводки</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        public async Task<ResponseBaseDto> CreateAccountHistoryTransferEntry(AccountDto sourceAccount,
                                               AccountDto destinationAccount, 
                                               bool isActiceSource,
                                               bool isActiveDestination,
                                               CreateTransferAccountCommand request,
                                               CancellationToken cancellationToken)
        {
            bool sourceIsPresent = true;
            bool destinationIsPresent = true;
            if (sourceAccount == null)
            {
                sourceAccount = _baseHelper.InitiateAccount(request.SourceAccountNumber, request.SourceAccountType, isActiceSource);
                sourceIsPresent = false;
            }
            if (destinationAccount == null)
            {
                destinationAccount = _baseHelper.InitiateAccount(request.DestinationAccountNumber, request.DestinationAccountType, isActiveDestination);
                destinationIsPresent = false;
            }

            var result = await _helper.FormAccountEntryResponse(sourceAccount, destinationAccount, request.OperationId, request.Amount, request.DueDate, request.Description, sourceIsPresent, destinationIsPresent);
            if (result is ResponseMessageDto)
                return result;

            return result;
        }        
    }
}
