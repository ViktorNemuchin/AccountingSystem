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
    public class CreateAccountHistoryHelper
    {
        private readonly AccountHistoryHelper _helper;
        private readonly IAccountsHistoryRepository _accountsHistoryRepository;
        private readonly IAccountRepository _accountRepository;


        public CreateAccountHistoryHelper(IAccountsHistoryRepository accountsHistoryRepository, IAccountRepository accountRepository) 
        {
            _accountRepository = accountRepository;
            _accountsHistoryRepository = accountsHistoryRepository;
            _helper = new AccountHistoryHelper(_accountRepository, _accountsHistoryRepository);
        }
        public async Task<ResponseBaseDto> CreateAccountHistorySoloEntry(AccountDto account,
                                                CreateAccountHistoryEntryCommand request, 
                                                CancellationToken  cancellationToken) 
        {
            if (account == null)
            {
                var createAccount = InitiateAccount(request.AccountNumber, request.AccountType);
                return await _helper.FormAccountEntryResponse(createAccount, request.OperationId, request.Amount, request.IsTopUp, request.ActualDate, request.Description, false);
            }

            return await _helper.FormAccountEntryResponse(account, request.OperationId, request.Amount, request.IsTopUp, request.ActualDate, request.Description, true);
        }
        public async Task<ResponseBaseDto> CreateAccountHistoryTransferEntry(AccountDto sourceAccount,
                                               AccountDto destinationAccount, 
                                               CreateTransferAccountCommand request,
                                               CancellationToken cancellationToken)
        {
            bool sourceIsPresent = true;
            bool destinationIsPresent = true;
  
            if (sourceAccount == null)
            {
                sourceAccount = InitiateAccount(request.SourceAccountNumber, request.SourceAccountType);
                sourceIsPresent = false;
            }

            if (destinationAccount == null)
            {
                destinationAccount = InitiateAccount(request.DestinationAccountNumber, request.DestinationAccountType);
                destinationIsPresent = false;
            }

            var result = await _helper.FormAccountEntryResponse(sourceAccount, destinationAccount, request.OperationId, request.Amount, request.ActualDate, request.Description, sourceIsPresent, destinationIsPresent);
            if (result is ResponseErrorDto)
                return result;


            return result;
        }


        private AccountDto InitiateAccount(string accountNumber, int accountType) => new AccountDto
        {
            AccountNumber = accountNumber,
            AccountType = accountType,
            Balance = 0M
        };
    }
}
