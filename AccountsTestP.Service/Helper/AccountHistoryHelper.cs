using AccountsTestP.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AccountsTestP.Data.IRepositories;
using AccountsTestP.Domain.Queries;
using AccountsTestP.Domain.Command;
using System.Threading;
using AccountsTestP.Domain.Models;

namespace AccountsTestP.Service.Helper
{
    public class AccountHistoryHelper
    {
        private readonly IAccountsHistoryRepository _accountsHistoryRepository;
        private readonly IAccountRepository _accountRepository;

        public AccountHistoryHelper( IAccountRepository accountRepository, IAccountsHistoryRepository accountsHistoryRepository)
        {
            _accountsHistoryRepository = accountsHistoryRepository;
            _accountRepository = accountRepository;

        }
        private decimal WithDrawlBalance(decimal balanceIn, decimal ammountIn) => balanceIn - ammountIn;

        private decimal TopUpBalance(decimal balanceIn, decimal ammountIn) => balanceIn + ammountIn;

        private bool ValidateAmmount(decimal balanceIn, decimal ammountIn) => ammountIn > balanceIn;

        public TransactionDto FormResult(AccountEntryDto sourceAccount, AccountEntryDto destinationAccount) => new TransactionDto
        {
            DestanationBalance = destinationAccount.CurrentBalance,
            SourceBalance = sourceAccount.CurrentBalance
        };
        public ResponseOkDto<TransactionDto> FormResponseForTransaction(TransactionDto result) => new ResponseOkDto<TransactionDto>
        {
            Status = "Ok",
            Result = result
        };
        private ResponseOkDto<AccountEntryDto> FormResponseForCreateEntry(AccountEntryDto result) => new ResponseOkDto<AccountEntryDto>
        {
            Status = "Ok",
            Result = result
        };

        public async Task<ResponseBaseDto> FormAccountEntryResponse(AccountDto account, decimal amount, bool isTopUp)  
        {

                var entry = new AccountHistoryModel(account.Id, amount);
                await _accountsHistoryRepository.AddEntry(entry);
                var initialBalance = account.Balance;
                var balance = new decimal();
                
                if (isTopUp)
                    balance = TopUpBalance(initialBalance, amount);   
                else
                    if (ValidateAmmount(initialBalance, amount))
                        return new ResponseErrorDto
                        {
                            Status = "error",
                            Message = "You can't withdraw so much amount of money."
                        };
                    else 
                        balance = WithDrawlBalance(initialBalance, amount);

                var accountModel = new AccountModel(account.Id, account.AccountNumber, balance);

                _accountRepository.Update(accountModel);

                if (await _accountsHistoryRepository.SaveChangesAsync() == 0)
                    throw new ApplicationException();


                var result = new AccountEntryDto
                {
                    CurrentBalance = balance
                };
            return FormResponseForCreateEntry(result);


        }
    }
}
