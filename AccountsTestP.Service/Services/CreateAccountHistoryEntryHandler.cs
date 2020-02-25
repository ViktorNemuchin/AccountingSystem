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
    public class CreateAccountHistoryEntryHandler : IRequestHandler<CreateAccountHistoryEntryCommand, ResponseBaseDto>
    {
        private readonly IAccountsHistoryRepository _accountsHistoryRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountHistoryBufferRepository _accountHistoryBufferRepository;
        private readonly IMediator _mediator;
        private readonly CreateAccountHistoryHelper _helper;
        private readonly AccountHistoryBufferHelper _bufferHelper;
        public CreateAccountHistoryEntryHandler(IMediator mediator, 
            IAccountRepository accountRepository, 
                                                IAccountsHistoryRepository accountsHistoryRepository, 
                                                IAccountHistoryBufferRepository accountHistoryBufferRepository )
        {
            _accountRepository = accountRepository;
            _accountsHistoryRepository = accountsHistoryRepository;
            _accountHistoryBufferRepository = accountHistoryBufferRepository;
            _mediator = mediator;
            _helper = new CreateAccountHistoryHelper(_accountsHistoryRepository,_accountRepository);
            _bufferHelper = new AccountHistoryBufferHelper(_accountHistoryBufferRepository, _accountRepository);
        }
        

        public async Task<ResponseBaseDto> Handle(CreateAccountHistoryEntryCommand request, CancellationToken cancellationToken)
        {
            var account = _mediator.Send(new GetAccountQuery(request.AccountNumber)).Result;
            var isPresent = true;
            if(account == null) 
            {
                isPresent = false;
            }
            var check = DateTime.Compare(DateTime.Now.Date, request.ActualDate.Date);
            return check switch
            {
                1 => null,
                -1 => await _bufferHelper.AddBuferEntry(account,request, isPresent, cancellationToken),
                _ => await _helper.CreateAccountHistorySoloEntry(account, request, cancellationToken),
            };
        }
    }

}
