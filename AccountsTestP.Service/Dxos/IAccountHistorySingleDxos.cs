using AccountsTestP.Domain.Command;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountsTestP.Service.Dxos
{
    public interface IAccountHistorySingleDxos
    {
        public AccountHistoryDto MapAccountHistoryModel(AccountHistoryModel entry);
    }
}
