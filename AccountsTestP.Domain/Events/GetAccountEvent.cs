using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using AccountsTestP.Domain.Dtos;

namespace AccountsTestP.Domain.Events
{
    public class GetAccountEvent: INotification

    {
        public int AccountId  { get; }

        public GetAccountEvent(int accountId) 
        {
            AccountId = accountId;
        }
    }
}
