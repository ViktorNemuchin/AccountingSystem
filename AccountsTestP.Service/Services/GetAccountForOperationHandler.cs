using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AccountsTestP.Data.IRepositories;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Queries;
using AccountsTestP.Service.Dxos;
using AccountsTestP.Service.Helper;
using MediatR;

namespace AccountsTestP.Service.Services
{
    public class GetAccountForOperationHandler: IRequestHandler<GetAccountHistoryForOperationQuery, ResponseBaseDto>
    {
        private readonly IAccountsHistoryRepository _accountsHistoryRepository;
        private readonly IAccountHistoryDxos _accountHistoryDxos;
        private readonly ReportCreatorHelper _helper;

        public GetAccountForOperationHandler(IAccountsHistoryRepository accountsHistoryRepository, IAccountHistoryDxos accountHistoryDxos) 
        {
            _accountHistoryDxos = accountHistoryDxos;
            _accountsHistoryRepository = accountsHistoryRepository;
            _helper = new ReportCreatorHelper(_accountHistoryDxos);
        }

        public async Task<ResponseBaseDto> Handle(GetAccountHistoryForOperationQuery request, CancellationToken cancellationToken)
        {
            var operationList = _helper.GetAccountList(await _accountsHistoryRepository.GetListForOperationAsync(request.OperationId));
            if (operationList.Count == 0)
                return null;
            return new ResponseOkDto<List<AccountHistoryDto>>
            {
                Status = "Ok",
                Result = operationList
            };

        }
    }
}
