using System;
using System.Collections.Generic;
using System.Text;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Queries;
using AccountsTestP.Service.Dxos;
using AccountsTestP.Data.IRepositories;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace AccountsTestP.Service.Services
{
    public class GetAccountHandler:IRequestHandler<GetAccountQuery, AccountDto> 
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountDxos _accountDxos;
        public GetAccountHandler(IAccountDxos accountDxos, IAccountRepository accountRepository ) 
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _accountDxos = accountDxos ?? throw new ArgumentNullException(nameof(accountDxos));
        }

        public async Task<AccountDto> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            
            {
                var account = await _accountRepository.GetAsync(e => e.Id == request.AccountId);
                if (account != null)
                {
                    var accountDto = _accountDxos.MapAccountDto(account);
                    return accountDto;
                }
                return null;
            }
         }
    }
}
