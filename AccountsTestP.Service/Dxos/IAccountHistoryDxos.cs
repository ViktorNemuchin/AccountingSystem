using System;
using System.Collections.Generic;
using System.Text;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Models;



namespace AccountsTestP.Service.Dxos
{
    public interface IAccountHistoryDxos
    {
       public AccountHistoryDto MapAccountHistoryDto(AccountHistoryModel entry);
    }
}
