using AccountsTestP.Data.IRepositories;
using AccountsTestP.Domain.Command;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Queries;
using AccountsTestP.Service.Helper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
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
            var sourceAccount = _mediator.Send(new GetAccountQuery(request.SourceAccountId)).Result;
            if (sourceAccount == null)
                return null;

            var destinationAccount = _mediator.Send(new GetAccountQuery(request.DestinationAccountId)).Result;
            if (destinationAccount == null)
                return null;

            var withdrawAccount = await _helper.FormAccountEntryResponse(sourceAccount, request.Amount, false);
            if (withdrawAccount is ResponseErrorDto) 
            {
                return withdrawAccount;
            }

            var topUpAccount = await _helper.FormAccountEntryResponse(destinationAccount, request.Amount, true);
            if (topUpAccount is ResponseErrorDto)
            {
                return topUpAccount;
            }
            var sourceResultAccount = withdrawAccount as ResponseOkDto<AccountEntryDto>;
            var destinationResultAccount = topUpAccount as ResponseOkDto<AccountEntryDto>;
            var result = _helper.FormResult(sourceResultAccount.Result, destinationResultAccount.Result);
            return _helper.FormResponseForTransaction(result);
        }
    }
    
}
