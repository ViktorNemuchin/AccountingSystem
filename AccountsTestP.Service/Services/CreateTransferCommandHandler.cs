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
    public class CreateTransferCommandHandler : IRequestHandler<CreateTransferAccountCommand, ResponseBaseDto>
    {
        private readonly IAccountsHistoryRepository _accountsHistoryRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMediator _mediator;
        private readonly AccountHistoryHelper _helper;

        public CreateTransferCommandHandler(IMediator mediator, IAccountRepository accountRepository, IAccountsHistoryRepository accountsHistoryRepository)
        {
            _accountsHistoryRepository = accountsHistoryRepository;
            _accountRepository = accountRepository;
            _mediator = mediator;
            _helper = new AccountHistoryHelper(_accountRepository, _accountsHistoryRepository);
        }

        public async Task<ResponseBaseDto> Handle(CreateTransferAccountCommand request, CancellationToken cancellationToken)
        {
            bool sourceIsPresent =true;
            bool destinationIsPresent = true;
            var sourceAccount = _mediator.Send(new GetAccountQuery(request.SourceAccountNumber)).Result;
            if (sourceAccount == null) 
            {
                sourceAccount = new AccountDto
                {
                    AccountNumber = request.SourceAccountNumber,
                    AccountType = request.SourceAccountType,
                    Balance = 0M,
                    DocumentId = request.DocumentId
                };
                sourceIsPresent = false;
            }
                

            var destinationAccount = _mediator.Send(new GetAccountQuery(request.DestinationAccountNumber)).Result;
            if (destinationAccount == null)
            {
                destinationAccount = new AccountDto
                {
                    AccountNumber = request.SourceAccountNumber,
                    AccountType = request.DestinationAccountType,
                    Balance = 0M,
                    DocumentId = request.DocumentId
                };
                destinationIsPresent = false;
            }

            var result = await _helper.FormAccountEntryResponse(sourceAccount, destinationAccount, request.Amount, request.ActualDate, sourceIsPresent,destinationIsPresent);
            if (result is ResponseErrorDto)
                return result;
            
   
            return result;
        }
    }

}
