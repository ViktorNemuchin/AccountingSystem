using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Models;
using System.Collections.Generic;

namespace AccountsTestP.Service.Dxos
{
    public interface IAccountHistoryDxos
    {
        public List<AccountHistoryDto> MapAccountHistoryDto(List<AccountHistoryModel> entry);
    }
}
