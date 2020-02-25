using AccountsTestP.Data.IRepositories;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountsTestP.Service.Helper
{
    public class AccountHistoryHelper
    {
        private readonly IAccountsHistoryRepository _accountsHistoryRepository;
        private readonly IAccountRepository _accountRepository;


        public AccountHistoryHelper(IAccountRepository accountRepository, IAccountsHistoryRepository accountsHistoryRepository)
        {
            _accountsHistoryRepository = accountsHistoryRepository;
            _accountRepository = accountRepository;
        }

        private ResponseOkDto<TransactionDto> FormResponseForCreateEntry(TransactionDto result) => new ResponseOkDto<TransactionDto>
        {
            Status = "Ok",
            Result = result
        };
 
        
        public async Task<ResponseBaseDto> FormAccountEntryResponse(AccountDto account,
                                                                    Guid operationId, 
                                                                    decimal amount, 
                                                                    bool isTopUp, 
                                                                    DateTimeOffset actualDate,
                                                                    string description, 
                                                                    bool accountPresent)
        {
            var initialBalance = account.Balance;   
            var balance = new decimal();
            AccountHistoryModel entry;
            if (isTopUp)
            {
                balance = TopUpBalance(initialBalance, amount);
                
            }
            else
            {
                if (ValidateAmmount(initialBalance, amount))
                {
                    return new ResponseErrorDto
                    {
                        Status = "error",
                        Message = "You can't withdraw so much amount of money."
                    };
                }
                else
                { 
                    balance = WithDrawlBalance(initialBalance, amount);
                }
            }
                
            
            if (accountPresent)
                UpdateAccount(account, balance);
            else
                account.Id = SaveAccount(account, balance);

            entry = new AccountHistoryModel(Guid.Empty, account.Id, amount, balance, actualDate, operationId, description);
            await _accountsHistoryRepository.AddEntry(entry);

            if (await _accountsHistoryRepository.SaveChangesAsync() == 0)
                throw new ApplicationException();


            var result = new AccountTransferDto
            {
                AccountId = account.Id,
                CurrentBalance = balance
            };
            return FormResponseForCreateEntry(result);
        }


        public async Task<ResponseBaseDto> FormAccountEntryResponse(AccountDto sourceAccount,
                                                                   AccountDto destinationAccount,
                                                                   Guid operationId, 
                                                                   decimal amount, 
                                                                   DateTimeOffset actualDate, 
                                                                   string comment, 
                                                                   bool sourceAccountPresent, 
                                                                   bool destinationAccountIsPresent)
        {
            var initialSourceBalance = sourceAccount.Balance;
            var initialDestinationBalance = destinationAccount.Balance;
            var sourceBalance = new decimal();
            if (ValidateAmmount(initialSourceBalance, amount))
                return FormErrorResponse("Error", "You can't withdraw so much amount of money.");
            else
                sourceBalance = WithDrawlBalance(initialSourceBalance, amount);
            
            if (sourceAccountPresent)
                UpdateAccount(sourceAccount, sourceBalance);
            else
               sourceAccount.Id = SaveAccount(sourceAccount, sourceBalance);
            
            var destinationBalance = TopUpBalance(initialDestinationBalance, amount);
            if (destinationAccountIsPresent)
                UpdateAccount(destinationAccount, destinationBalance);
            else
                destinationAccount.Id = SaveAccount(destinationAccount, destinationBalance);
            

            var entry = new AccountHistoryModel(destinationAccount.Id, sourceAccount.Id, amount, sourceBalance, destinationBalance, actualDate, comment, operationId);
            await _accountsHistoryRepository.AddEntry(entry);

            if (await _accountsHistoryRepository.SaveChangesAsync() == 0)
                throw new ApplicationException();


            var result = new TransactionDto
            {
                DestinationAccountId = destinationAccount.Id,
                SourceAccountId = sourceAccount.Id,

            };
            return FormResponseForCreateEntry(result);
        }

        
        
        private decimal WithDrawlBalance(decimal balanceIn, decimal ammountIn) => balanceIn - ammountIn;

        private decimal TopUpBalance(decimal balanceIn, decimal ammountIn) => balanceIn + ammountIn;

        private bool ValidateAmmount(decimal balanceIn, decimal ammountIn) => ammountIn > balanceIn;

        private ResponseOkDto<AccountTransferDto> FormResponseForCreateEntry(AccountTransferDto result) => new ResponseOkDto<AccountTransferDto>
        {
            Status = "Ok",
            Result = result
        };

        private ResponseErrorDto FormErrorResponse(string status, string message) => new ResponseErrorDto
        {
            Status = status,
            Message = message
        };

        private Guid SaveAccount(AccountDto account, decimal balance)
        {
            var accountModel = new AccountModel(account.AccountNumber, balance, account.AccountType);
            _accountRepository.AddAccount(accountModel);
            return accountModel.Id;
        }

        private void UpdateAccount(AccountDto account, decimal balance)
        {
            var accountModel = new AccountModel(account.Id, account.AccountNumber, balance, account.AccountType);
            _accountRepository.Update(accountModel);
        }
    }
}
