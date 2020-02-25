using AccountsTestP.Data.IRepositories;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Models;
using AccountsTestP.Domain.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AccountsTestP.Service.Helper
{
    public class AccountHistoryBufferHelper
    {
        private readonly IAccountHistoryBufferRepository _accountHistoryBufferRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly BaseHelper _baseHelper;
        
        public AccountHistoryBufferHelper(IAccountHistoryBufferRepository accountHistoryBufferRepository, IAccountRepository accountRepository)
        {
            _accountHistoryBufferRepository = accountHistoryBufferRepository;
            _accountRepository = accountRepository;
            _baseHelper = new BaseHelper(_accountRepository);
        }
        //private Guid SaveAccount(AccountDto account)
        //{
        //    var accountModel = new AccountModel(account.AccountNumber, account.Balance, account.AccountType);
        //    _accountRepository.AddAccount(accountModel);
        //    return accountModel.Id;
        //}
        public async Task<ResponseBaseDto> AddBuferEntry(AccountDto account, CreateAccountHistoryEntryCommand request, bool isPresent, CancellationToken cancellationToken) 
        {
            
            if (!isPresent) 
            {
                account.Id = await _baseHelper.SaveAccount(account,0M);
            }

            if (request.IsTopUp)
            {
                 await _accountHistoryBufferRepository.AddBufferEntry(new BufferForFutureEntriesDatesModel(Guid.Empty,account.Id, request.Amount, request.OperationId, request.ActualDate, request.Description));
            }
            else
            {
                 await _accountHistoryBufferRepository.AddBufferEntry(new BufferForFutureEntriesDatesModel(account.Id,Guid.Empty, request.Amount, request.OperationId, request.ActualDate, request.Description));
            }
            await _accountHistoryBufferRepository.SaveChangesAsync();
            var result = new AccountTransferDto
            {
                AccountId = account.Id,
                CurrentBalance = account.Balance
            };
            return _baseHelper.FormResponseForCreateEntrySolo(result);
        }
        public async Task<ResponseBaseDto> AddBuferEntry(AccountDto sourceAccount, AccountDto destinationAccount, CreateTransferAccountCommand request, bool isSourcePresent, bool isDestinationPresent, CancellationToken cancellationToken)
        {

            if (!isSourcePresent)
            {
                sourceAccount.Id = await _baseHelper.SaveAccount(sourceAccount, 0M);
            }

            if (!isDestinationPresent)
            {
                sourceAccount.Id = await _baseHelper.SaveAccount(destinationAccount, 0M);
            }

            await _accountHistoryBufferRepository.AddBufferEntry(new BufferForFutureEntriesDatesModel(sourceAccount.Id,destinationAccount.Id, request.Amount, request.OperationId, request.ActualDate, request.Description));
            await _accountHistoryBufferRepository.SaveChangesAsync();
            var result = new TransactionDto
            {
                DestinationAccountId = destinationAccount.Id,
                SourceAccountId =sourceAccount.Id

            };
            return _baseHelper.FormResponseForCreateEntryTransaction(result);
        }

    }
}
