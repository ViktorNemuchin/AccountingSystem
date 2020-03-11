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
    /// <summary>
    /// Класс handler'а и обработчика команды на создание счета
    /// </summary>
    public class CreateAccountHandler: IRequestHandler<CreateAccountCommand, ResponseBaseDto>
    {

        private readonly IAccountRepository _accountRepository;
        /// <summary>
        /// Конструктор handler'а и обработчика команды на создание счета
        /// </summary>
        /// <param name="accountRepository">Класс методов работы с таблицами счетов</param>
        public CreateAccountHandler(IAccountRepository accountRepository) 
        {
    
            _accountRepository = accountRepository;
       }
        /// <summary>
        /// Handler и обработчик комманды на создание счета
        /// </summary>
        /// <param name="request">Команда на создание счета</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Возвращает ответ типа ResponseBAseDto на выполнение команды для внешних сервисов</returns>
        public async Task<ResponseBaseDto> Handle(CreateAccountCommand request, CancellationToken cancellationToken) 
        {
            var account = new AccountModel(request.AccountNumber, request.InitialBalance, request.AccountType);
            await _accountRepository.AddAccount(account);

            return new ResponseOkDto<AccountModel>
            {
                Status = "Ok",
                Result = account
            };
        }
    }
}
