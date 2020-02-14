using AccountsTestP.Data.IRepositories;
using AccountsTestP.Domain.Command;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Queries;
using AccountsTestP.Service.Helper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace AccountsTestP.Service.Services
{
    public class CreateAccountHistoryEntryHandler : IRequestHandler<CreateAccountHistoryEntryCommand, ResponseBaseDto>
    {
        private readonly IAccountsHistoryRepository _accountsHistoryRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMediator _mediator;
        private readonly AccountHistoryHelper _helper;
        public CreateAccountHistoryEntryHandler(IMediator mediator, IAccountRepository accountRepository, IAccountsHistoryRepository accountsHistoryRepository)
        {
            _accountRepository = accountRepository;
            _accountsHistoryRepository = accountsHistoryRepository;
            _mediator = mediator;
            _helper = new AccountHistoryHelper(_accountRepository, _accountsHistoryRepository);
        }

        public async Task<ResponseBaseDto> Handle(CreateAccountHistoryEntryCommand request, CancellationToken cancellationToken)
        {
  
            var account = _mediator.Send(new GetAccountQuery(request.AccountNumber)).Result;
            if (account == null) 
            {
                var createAccount = new AccountDto
                {
                    AccountNumber = request.AccountNumber,
                    AccountType = request.AccountType,
                    Balance = 0M,
                    DocumentId = request.DocumentId
                };
                return await _helper.FormAccountEntryResponse(createAccount, request.Amount, request.IsTopUp, request.ActualDate, false);
            }
               
            return await _helper.FormAccountEntryResponse(account, request.Amount, request.IsTopUp, request.ActualDate, true);

        }
    }

}
