using AccountsTestP.Data.IRepositories;
using AccountsTestP.Service.Dxos;
using AccountsTestP.Domain.Command;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Models;
using AccountsTestP.Domain.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AccountsTestP.Service.Helper;


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
            var account = _mediator.Send(new GetAccountQuery(request.AccountId)).Result;
            if (account!= null)
                return await _helper.FormAccountEntryResponse(account, request.Amount, request.IsTopUp);
            return null;

        }
    }

}
