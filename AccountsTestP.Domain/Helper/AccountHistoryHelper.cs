using System;
using System.Collections.Generic;
using System.Text;

namespace AccountsTestP.Domain.Helper
{
    public class AccountHistoryHelper
    {
        public decimal WithDrawlAccountBalance(decimal balanceIn, decimal ammountIn) => balanceIn - ammountIn;
        public decimal TopUpAccountBalance(decimal balanceIn, decimal ammountIn) => balanceIn + ammountIn;
    }
}
