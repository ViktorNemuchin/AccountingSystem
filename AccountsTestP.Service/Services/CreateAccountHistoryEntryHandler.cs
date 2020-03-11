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
    /// Класс handler'а команды на создание записи в журнале проводок поплнения и списания со счета.
    /// </summary>
    public class CreateAccountHistoryEntryHandler : IRequestHandler<CreateAccountHistoryEntryCommand, ResponseBaseDto>
    {
        private readonly IAccountsHistoryRepository _accountsHistoryRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountHistoryBufferRepository _accountHistoryBufferRepository;
        private readonly IMediator _mediator;
        private readonly CreateAccountHistoryHelper _helper;
        private readonly AccountHistoryBufferHelper _bufferHelper;
        private readonly PastDueDateAccountEntryHelper _pastDueDateAccountEntryHelper;
        /// <summary>
        /// Конструктор handler'а команды на создание записи в журнале проводок о поплнении и списании со счета. 
        /// </summary>
        /// <param name="mediator">Экземпляр класса MediatR</param>
        /// <param name="accountRepository">Объект типа класса работы с таблицей счетов</param>
        /// <param name="accountsHistoryRepository">Объект типа класса работы с таблицей журнала проводок</param>
        /// <param name="accountHistoryBufferRepository"> Объект типа класса работы с таблицей буфера проводок</param>
        public CreateAccountHistoryEntryHandler(IMediator mediator, 
                                                IAccountRepository accountRepository, 
                                                IAccountsHistoryRepository accountsHistoryRepository, 
                                                IAccountHistoryBufferRepository accountHistoryBufferRepository)
        {
            _accountRepository = accountRepository;
            _accountsHistoryRepository = accountsHistoryRepository;
            _accountHistoryBufferRepository = accountHistoryBufferRepository;
            _mediator = mediator;
            _helper = new CreateAccountHistoryHelper(_accountsHistoryRepository,_accountRepository);
            _bufferHelper = new AccountHistoryBufferHelper(_accountHistoryBufferRepository, _accountRepository);
            _pastDueDateAccountEntryHelper = new PastDueDateAccountEntryHelper(_mediator, _accountsHistoryRepository, _accountRepository);
        }

        /// <summary>
        /// Handler команды записи в журнале проводок о поплнении и списании со счета.
        /// </summary>
        /// <param name="request">Команда для создания записи в журнале проводок о пополнении или спсиании со счета</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        public async Task<ResponseBaseDto> Handle(CreateAccountHistoryEntryCommand request, CancellationToken cancellationToken)
        {
            var account = _mediator.Send(new GetAccountQuery(request.AccountNumber)).Result;
            var check = DateTime.Compare(DateTime.Now.Date, request.DueDate.Date);
            return check switch
            {
                1 => await _pastDueDateAccountEntryHelper.TryRecalculateEntriesForSolo(account, request, cancellationToken),
                -1 => await _bufferHelper.AddBuferEntry(account,request, cancellationToken),
                _ => await _helper.CreateAccountHistorySoloEntry(account, request, cancellationToken),
            };
        }
    }

}
