using AccountsTestP.Data.IRepositories;
using AccountsTestP.Domain.Command;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Service.Helper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AccountsTestP.Service.Dxos;
using AccountsTestP.Domain.Models;

namespace AccountsTestP.Service.Services
{
    public class CreateAccountHandler: IRequestHandler<CreateAccountCommand, ResponseBaseDto>
    {
        private readonly IAccountRepository _accountRepository;

        public CreateAccountHandler(IAccountRepository accountRepository) 
        {
    
            _accountRepository = accountRepository;
       }

        public async Task<ResponseBaseDto> Handle(CreateAccountCommand request, CancellationToken cancellationToken) 
        {
            var account = new AccountModel(request.AccountNumber, request.InitialBalance, request.OperationId, request.AccountType);
            await _accountRepository.AddAccount(account);

            return new ResponseOkDto<AccountModel>
            {
                Status = "Ok",
                Result = account
            };
        }
    }
}
