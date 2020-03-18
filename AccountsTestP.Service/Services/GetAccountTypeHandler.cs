using AccountsTestP.Data.IRepositories;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Queries;
using AccountsTestP.Domain.Models;
using AccountsTestP.Service.Dxos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AccountsTestP.Service.Services
{
    /// <summary>
    /// Класс handler'а для запроса типа счета по его номеру
    /// </summary>
    public class GetAccountTypeHandler : IRequestHandler<GetAccountTypeQuery, ResponseBaseDto>
    {
        private readonly IAccountTypeRepository _accountTypeRepository;
        /// <summary>
        /// Конструктор handler'а для запроса типа счета по его номеру.
        /// </summary>
        /// <param name="accountTypeRepository">Объект класса методов работы с таблицей Типов счетов</param>
        public GetAccountTypeHandler(IAccountTypeRepository accountTypeRepository) 
        {
            _accountTypeRepository = accountTypeRepository;
        }
        /// <summary>
        /// Метод вызываемый handler' при получении запроса типа счета
        /// </summary>
        /// <param name="request">Объект с входными параметрами запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>возвращает объект типа счета</returns>
        public async Task<ResponseBaseDto> Handle(GetAccountTypeQuery request, CancellationToken cancellationToken)
        {
            return new ResponseOkDto<AccountTypeModel>
            {
                Status = "Ok",
                Result = await _accountTypeRepository.GetAccountType(request.AccountTypeNumber)
            };
        }
       
            
    }
}
