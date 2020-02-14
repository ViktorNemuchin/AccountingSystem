using AccountsTestP.Data.IRepositories;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Queries;
using AccountsTestP.Service.Dxos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AccountsTestP.Service.Services
{
    public class GetAccountHandler : IRequestHandler<GetAccountQuery, AccountDto>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountDxos _accountDxos;
        public GetAccountHandler(IAccountDxos accountDxos, IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _accountDxos = accountDxos ?? throw new ArgumentNullException(nameof(accountDxos));
        }

        public async Task<AccountDto> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            {
                var account = await _accountRepository.GetAsync(e => e.AccountNumber == request.AccountNumber);
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
