using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace AccountsTestP.Domain.Command
{
    public class CommandBase<T> : IRequest<T> where T : class
    {

    }
    
}
