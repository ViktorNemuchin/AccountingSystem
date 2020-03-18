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
    /// <summary>
    /// Класс handler'а запроса на получение текущей информации по счету по  Id счета
    /// </summary>
    public class GetAccountHandler : IRequestHandler<GetAccountQuery, AccountDto>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountTypeRepository _accountTypeRepository;
        private readonly IAccountDxos _accountDxos;
        /// <summary>
        /// Конструктор handler'а запроса на получение текущей информации по счету по  Id счета
        /// </summary>
        /// <param name="accountDxos">Объект экземпляра класса методов для преобразования сущности модели счета в с DTO счета для передачи</param>
        /// <param name="accountRepository">Объект класса работы с таблицей счетов<</param>
        public GetAccountHandler(IAccountDxos accountDxos, IAccountRepository accountRepository, IAccountTypeRepository accountTypeRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _accountTypeRepository = accountTypeRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _accountDxos = accountDxos ?? throw new ArgumentNullException(nameof(accountDxos));
        }
        /// <summary>
        /// Handler запроса на получение текущей информации по счету по  Id счета
        /// </summary>
        /// <param name="request">Объект запроса на получение текущей информации по счету по  Id счета</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        public async Task<AccountDto> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            {
                var account = await _accountRepository.GetAsync(e => e.AccountNumber == request.AccountNumber);
                
                if (account != null)
                {
                    var isActice = await _accountTypeRepository.GetAccountType(account.AccountType);
                    var accountDto = _accountDxos.MapAccountDto(account);
                    accountDto.IsActive = isActice.IsActive;
                    return accountDto;
                }
                return null;
            }
        }
    }
}
