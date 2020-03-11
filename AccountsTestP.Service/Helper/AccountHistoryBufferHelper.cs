using AccountsTestP.Data.IRepositories;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Models;
using AccountsTestP.Domain.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AccountsTestP.Service.Helper
{
    /// <summary>
    /// Класс вспомогательных методов для работы с буфером проводок 
    /// </summary>
    public class AccountHistoryBufferHelper
    {
        private readonly IAccountHistoryBufferRepository _accountHistoryBufferRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly BaseHelper _baseHelper;
        private readonly string message = "Запись помещена в буфер проводок";
        private readonly string ok = "Ok";
        /// <summary>
        /// Конструктор класса методов для работы с буфером проводок
        /// </summary>
        /// <param name="accountHistoryBufferRepository"> Объект типа класса работы с таблицей буфера проводок</param>
        /// <param name="accountRepository">Объект типа класса работы с таблицей счетов</param>
        public AccountHistoryBufferHelper(IAccountHistoryBufferRepository accountHistoryBufferRepository, IAccountRepository accountRepository)
        {
            _accountHistoryBufferRepository = accountHistoryBufferRepository;
            _accountRepository = accountRepository;
            _baseHelper = new BaseHelper(_accountRepository);
        }
        /// <summary>
        /// Созлание записи в таблице модуля проводок
        /// </summary>
        /// <param name="account">DTO счета</param>
        /// <param name="request">Сущность комманды на создание счета</param>
        /// <param name="cancellationToken">Токе отмены</param>
        /// <returns></returns>
        public async Task<ResponseBaseDto> AddBuferEntry(AccountDto account, 
                                                         CreateAccountHistoryEntryCommand request, 
                                                         CancellationToken cancellationToken) 
        {

            var emptyAccount = "00000000000000000000";
            if (request.IsTopUp)
            {
                 await _accountHistoryBufferRepository.AddBufferEntry(new BufferForFutureEntriesDatesModel(emptyAccount,
                     request.AccountNumber,
                     request.Amount,
                     request.DueDate.Date,
                     request.OperationId,
                     0, 
                     request.AccountType,                   
                     request.Description));
            }
            else
            {
                 await _accountHistoryBufferRepository.AddBufferEntry(new BufferForFutureEntriesDatesModel(request.AccountNumber, 
                     emptyAccount,
                     request.Amount,
                     request.DueDate.Date,
                     request.OperationId,
                     request.AccountType,
                     0,
                     request.Description ));
            }
            await _accountHistoryBufferRepository.SaveChangesAsync();

            return _baseHelper.FormMessageResponse(ok, message);
        }
        /// <summary>
        /// Созлание записи в таблице модуля проводок
        /// </summary>
        /// <param name="sourceAccount">DTO счета с которого совершается проводка</param>
        /// <param name="destinationAccount">DTO счета на который совершается проводка</param>
        /// <param name="request">Сущность комманды на создание счета</param>
        /// <param name="isSourcePresent">Присутствует ли счет с которго совершается проводка</param>
        /// <param name="isDestinationPresent">Присутсвует ли счет на который совершается проводка</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ResponseBaseDto> AddBuferEntry(AccountDto sourceAccount,
                                                         AccountDto destinationAccount, 
                                                         CreateTransferAccountCommand request, 
                                                         bool isSourcePresent, 
                                                         bool isDestinationPresent, 
                                                         CancellationToken cancellationToken)
        {

            await _accountHistoryBufferRepository.AddBufferEntry(new BufferForFutureEntriesDatesModel(request.SourceAccountNumber,
                request.DestinationAccountNumber, 
                request.Amount, 
                request.DueDate.Date,
                request.OperationId,
                request.SourceAccountType,
                request.DestinationAccountType,
                request.Description));
            await _accountHistoryBufferRepository.SaveChangesAsync();
            
            return _baseHelper.FormMessageResponse(ok, message );
        }

    }
}
