using AccountsTestP.Data.IRepositories;
using AccountsTestP.Domain.Command;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Queries;
using AccountsTestP.Service.Helper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AccountsTestP.Service.Services
{
    public class CreateTransferCommandHandler : IRequestHandler<CreateTransferAccountCommand, ResponseBaseDto>
    {
        private readonly IAccountsHistoryRepository _accountsHistoryRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountHistoryBufferRepository _bufferRepository;
        private readonly IMediator _mediator;
        private readonly CreateAccountHistoryHelper _helper;
        private readonly AccountHistoryBufferHelper _bufferHelper;


        public CreateTransferCommandHandler(IMediator mediator, IAccountRepository accountRepository, IAccountsHistoryRepository accountsHistoryRepository, IAccountHistoryBufferRepository bufferRepository)
        {
            _accountsHistoryRepository = accountsHistoryRepository;
            _accountRepository = accountRepository;
            _bufferRepository = bufferRepository;
            _mediator = mediator;
            _helper = new CreateAccountHistoryHelper(_accountsHistoryRepository, _accountRepository);
            _bufferHelper = new AccountHistoryBufferHelper(_bufferRepository, _accountRepository);
        }

        public async Task<ResponseBaseDto> Handle(CreateTransferAccountCommand request, CancellationToken cancellationToken)
        {
            bool isSourcePresent =true;
            bool isDestinationPresent = true;
            var sourceAccount = _mediator.Send(new GetAccountQuery(request.SourceAccountNumber)).Result;
            if (sourceAccount == null)
            {
                isSourcePresent = false;
            }
            var destinationAccount = _mediator.Send(new GetAccountQuery(request.DestinationAccountNumber)).Result;
            if (destinationAccount == null)
            {
                isDestinationPresent = false;
            }
            var check = DateTimeOffset.Compare(DateTimeOffset.Now.Date, request.ActualDate.Date);
            return check switch
            {
                1 => null,
                -1 => await _bufferHelper.AddBuferEntry(sourceAccount,destinationAccount, request, isSourcePresent,isDestinationPresent, cancellationToken),
                _ => await _helper.CreateAccountHistoryTransferEntry(sourceAccount,destinationAccount, request, cancellationToken),
            };
        }
    }

}
