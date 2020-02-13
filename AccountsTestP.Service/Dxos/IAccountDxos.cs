using System;
using System.Collections.Generic;
using System.Text;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Models;

namespace AccountsTestP.Service.Dxos
{
    public interface IAccountDxos
    {
        AccountDto MapAccountDto(AccountModel entry);
    }
}
