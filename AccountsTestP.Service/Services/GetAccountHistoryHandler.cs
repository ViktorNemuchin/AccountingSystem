using AccountsTestP.Data.IRepositories;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Queries;
using AccountsTestP.Service.Dxos;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AccountsTestP.Service.Services
{
    public class GetAccountHistoryHandler : IRequestHandler<GetAccountHistoryQuery, ResponseBaseDto>
    {
        private readonly IAccountsHistoryRepository _accountsHistoryRepository;
        private readonly IAccountHistoryDxos _accountHistoryDxos;
        public GetAccountHistoryHandler(IAccountsHistoryRepository accountsHistoryRepository, IAccountHistoryDxos accountHistoryDxos)
        {
            _accountHistoryDxos = accountHistoryDxos;
            _accountsHistoryRepository = accountsHistoryRepository;
        }

        public async Task<ResponseBaseDto> Handle(GetAccountHistoryQuery request, CancellationToken cancellationToken)
        {
            var accountEntryList = await _accountsHistoryRepository.GetListAsync(request.AccountId);
            if (accountEntryList.Count != 0)
            {
                var accountHistoryDtoList = new List<AccountHistoryDto>();
                foreach (var entry in accountEntryList)
                {
                    accountHistoryDtoList.Add(_accountHistoryDxos.MapAccountHistoryDto(entry));
                };
                accountHistoryDtoList.Reverse();
                return new ResponseOkDto<List<AccountHistoryDto>>
                {
                    Status = "Ok",
                    Result = accountHistoryDtoList.ToList()
                };
            }
            return null;
        }
    }

}
