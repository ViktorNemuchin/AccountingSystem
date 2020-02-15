using AccountsTestP.Data.IRepositories;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Models;
using System;
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
        private decimal WithDrawlBalance(decimal balanceIn, decimal ammountIn) => balanceIn - ammountIn;

        private decimal TopUpBalance(decimal balanceIn, decimal ammountIn) => balanceIn + ammountIn;

        private bool ValidateAmmount(decimal balanceIn, decimal ammountIn) => ammountIn > balanceIn;

        public TransactionDto FormResult(AccountEntryDto sourceAccount, AccountEntryDto destinationAccount) => new TransactionDto
        {
            DestanationBalance = destinationAccount.CurrentBalance,
            SourceBalance = sourceAccount.CurrentBalance
        };
        public ResponseOkDto<TransactionDto> FormResponseForCreateEntry(TransactionDto result) => new ResponseOkDto<TransactionDto>
        {
            Status = "Ok",
            Result = result
        };
        private ResponseOkDto<AccountEntryDto> FormResponseForCreateEntry(AccountEntryDto result) => new ResponseOkDto<AccountEntryDto>
        {
            Status = "Ok",
            Result = result
        };
        public Guid SaveAccount(AccountDto account, decimal balance) 
        {
            var accountModel = new AccountModel(account.AccountNumber, balance,  account.AccountType);
            _accountRepository.AddAccount(accountModel);
            return accountModel.Id;
        }
        private void UpdateAccount(AccountDto account, decimal balance) 
        {
            var accountModel = new AccountModel(account.Id, account.AccountNumber, balance,  account.AccountType);
            _accountRepository.Update(accountModel);
        }
        public async Task<ResponseBaseDto> FormAccountEntryResponse(AccountDto account,Guid operationId, decimal amount, bool isTopUp, DateTime actualDate,int purpose, bool accountPresent)
        {
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
            
            if (accountPresent)
                UpdateAccount(account, balance);
            else
                account.Id = SaveAccount(account, balance);
            
            var entry = new AccountHistoryModel(account.Id, amount, actualDate, purpose, operationId);
            await _accountsHistoryRepository.AddEntry(entry);


            if (await _accountsHistoryRepository.SaveChangesAsync() == 0)
                throw new ApplicationException();


            var result = new AccountEntryDto
            {
                AccountId = account.Id,
                CurrentBalance = balance
            };
            return FormResponseForCreateEntry(result);


        }
        public async Task<ResponseBaseDto> FormAccountEntryResponse(AccountDto sourceAccount,AccountDto destinationAccount,Guid operationId, decimal amount, DateTime actualDate, int purpose, bool sourceAccountPresent, bool destinationAccountIsPresent)
        {
            var initialSourceBalance = sourceAccount.Balance;
            var initialDestinationBalance = destinationAccount.Balance;
            var sourceBalance = new decimal(); 
            if (ValidateAmmount(initialSourceBalance, amount))
                return new ResponseErrorDto
                {
                    Status = "error",
                    Message = "You can't withdraw so much amount of money."
                };
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
            

            var entry = new AccountHistoryModel(destinationAccount.Id, sourceAccount.Id, amount, actualDate, purpose, operationId);
            await _accountsHistoryRepository.AddEntry(entry);

            if (await _accountsHistoryRepository.SaveChangesAsync() == 0)
                throw new ApplicationException();


            var result = new TransactionDto
            {
                DestinationAccountId = destinationAccount.Id,
                DestanationBalance = destinationBalance,
                SourceAccountId = sourceAccount.Id,
                SourceBalance = sourceBalance

            };
            return FormResponseForCreateEntry(result);
        }
    }
}
