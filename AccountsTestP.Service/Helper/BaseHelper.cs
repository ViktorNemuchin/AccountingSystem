using AccountsTestP.Data.IRepositories;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountsTestP.Service.Helper
{
    public class BaseHelper
    {
        private readonly IAccountRepository _accountRepository;
        public BaseHelper(IAccountRepository accountRepository) 
        {
            _accountRepository = accountRepository;
        }

        public ResponseOkDto<TransactionDto> FormResponseForCreateEntryTransaction(TransactionDto result) => new ResponseOkDto<TransactionDto>
        {
            Status = "Ok",
            Result = result
        };

        public ResponseOkDto<AccountTransferDto> FormResponseForCreateEntrySolo(AccountTransferDto result) => new ResponseOkDto<AccountTransferDto>
        {
            Status = "Ok",
            Result = result
        };
        
        public ResponseErrorDto FormErrorResponse(string status, string message) => new ResponseErrorDto
        {
            Status = status,
            Message = message
        };

        public async Task<Guid> SaveAccount(AccountDto account, decimal balance)
        {
            var accountModel = new AccountModel(account.AccountNumber, balance, account.AccountType);
            await _accountRepository.AddAccount(accountModel);
            return accountModel.Id;
        }



    }
}
