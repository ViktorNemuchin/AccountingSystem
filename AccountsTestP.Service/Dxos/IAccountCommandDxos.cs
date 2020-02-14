using AccountsTestP.Domain.Command;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountsTestP.Service.Dxos
{
    public interface IAccountCommandDxos
    {
        public AccountModel MapAccountModel(CreateAccountCommand entry);
    }
}
