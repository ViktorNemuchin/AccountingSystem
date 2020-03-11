using MediatR;

namespace AccountsTestP.Domain.Events
{
    public class GetAccountEvent : INotification

    {
        public int AccountId { get; }

        public GetAccountEvent(int accountId)
        {
            AccountId = accountId;
        }
    }
}
