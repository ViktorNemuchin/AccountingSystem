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
    /// <summary>
    /// Класс handler'а команды на создание записи в журнале проводок о проведении проводки с одного счета на другой.
    /// </summary>
    public class CreateTransferCommandHandler : IRequestHandler<CreateTransferAccountCommand, ResponseBaseDto>
    {
        private readonly IAccountsHistoryRepository _accountsHistoryRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountHistoryBufferRepository _bufferRepository;
        private readonly IMediator _mediator;
        private readonly CreateAccountHistoryHelper _helper;
        private readonly AccountHistoryBufferHelper _bufferHelper;
        private readonly PastDueDateAccountEntryHelper _pastDueDateAccountEntryHelper;
        /// <summary>
        /// Конструктор handler'а команды на создание записи в журнале проводок о проведении проводки с одного счета на другой.
        /// </summary>
        /// <param name="mediator">Экземпляр класса MediatR</param>
        /// <param name="accountRepository">Объект типа класса работы с таблицей счетов</param>
        /// <param name="accountsHistoryRepository">Объект типа класса работы с таблицей журнала проводок</param>
        /// <param name="bufferRepository">Объект типа класса работы с таблицей буфера проводок</param>
        public CreateTransferCommandHandler(IMediator mediator, IAccountRepository accountRepository, IAccountsHistoryRepository accountsHistoryRepository, IAccountHistoryBufferRepository bufferRepository)
        {
            _accountsHistoryRepository = accountsHistoryRepository;
            _accountRepository = accountRepository;
            _bufferRepository = bufferRepository;
            _mediator = mediator;
            _helper = new CreateAccountHistoryHelper(_accountsHistoryRepository, _accountRepository);
            _bufferHelper = new AccountHistoryBufferHelper(_bufferRepository, _accountRepository);
            _pastDueDateAccountEntryHelper = new PastDueDateAccountEntryHelper(_mediator, _accountsHistoryRepository, _accountRepository);
        }
        /// <summary>
        /// Handler команды на создание записи в журнале проводок о проведении проводки с одного счета на другой.
        /// </summary>
        /// <param name="request">Команда на создание записи в журнале проводок о проведении проводки с одного счета на другой.</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        public async Task<ResponseBaseDto> Handle(CreateTransferAccountCommand request, CancellationToken cancellationToken)
        {
            var emptyAccount = "00000000000000000000";
            bool isSourcePresent =true;
            bool isDestinationPresent = true;
            var sourceAccount = new AccountDto();
            var destinationAccount = new AccountDto();

            
            if (request.SourceAccountNumber != emptyAccount) 
                sourceAccount = _mediator.Send(new GetAccountQuery(request.SourceAccountNumber)).Result;
            else
            {
                sourceAccount.AccountNumber = emptyAccount;
                sourceAccount.Id = Guid.Empty;
            }
  
            if (request.DestinationAccountNumber != emptyAccount)
                destinationAccount = _mediator.Send(new GetAccountQuery(request.DestinationAccountNumber)).Result;
            else
            {
                destinationAccount.AccountNumber = emptyAccount;
                destinationAccount.Id = Guid.Empty;
            }
                
            
            var check = DateTimeOffset.Compare(DateTimeOffset.Now.Date, request.DueDate.Date);
            return check switch
            {
                1 => await _pastDueDateAccountEntryHelper.TryRecalculateEntriesForTransfer(sourceAccount, destinationAccount, request, cancellationToken),
                -1 => await _bufferHelper.AddBuferEntry(sourceAccount,destinationAccount, request, isSourcePresent,isDestinationPresent, cancellationToken),
                _ => await _helper.CreateAccountHistoryTransferEntry(sourceAccount,destinationAccount, request, cancellationToken),
            };
        }
    }

}
