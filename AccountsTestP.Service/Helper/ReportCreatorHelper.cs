using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Models;
using AccountsTestP.Service.Dxos;

namespace AccountsTestP.Service.Helper
{
    public class ReportCreatorHelper
    {
        private readonly IAccountHistoryDxos _accountHistoryDxos;
        public ReportCreatorHelper(IAccountHistoryDxos accountHistoryDxos) 
        {
            _accountHistoryDxos = accountHistoryDxos;
        }

        public List<AccountHistoryDto> GetAccountList(List<AccountHistoryModel> entryList)
        {
            return _accountHistoryDxos.MapAccountHistoryDto(entryList);
        }

    }
}
