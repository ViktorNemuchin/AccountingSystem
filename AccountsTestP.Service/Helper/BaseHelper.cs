using AccountsTestP.Data.IRepositories;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountsTestP.Service.Helper
{
    public class BaseHelper
    {
        /// <summary>
        /// Класс базовыъх вспомогательнных методов работы с модулем регистрации проводок
        /// </summary>
        private readonly IAccountRepository _accountRepository;
        /// <summary>
        /// Конструктор класса базовыъх вспомогательнных методов работы с модулем регистрации проводок
        /// </summary>
        /// <param name="accountRepository">Объект типа класса работы с таблицей счетов</param>
        public BaseHelper(IAccountRepository accountRepository) 
        {
            _accountRepository = accountRepository;
        }
        /// <summary>
        /// Уменшение баланс счета на сумму
        /// </summary>
        /// <param name="balanceIn">Входящий баланс</param>
        /// <param name="ammountIn">Сумма изменения</param>
        /// <returns>Баланс счета  с учетом изменения</returns>
        public decimal WithDrawlBalance(decimal balanceIn, decimal ammountIn) => balanceIn - ammountIn;
        /// <summary>
        /// Увеличение баланса счета на сумму
        /// </summary>
        /// <param name="balanceIn">Входящий баланс счета</param>
        /// <param name="ammountIn">Сумма изменения</param>
        /// <returns>Исходящий баланс</returns>
        public decimal TopUpBalance(decimal balanceIn, decimal ammountIn) => balanceIn + ammountIn;
        /// <summary>
        /// Проверка наличия необходимых средств на счете для совершения проводки
        /// </summary>
        /// <param name="balanceIn">Входящий баланс счета</param>
        /// <param name="ammountIn">Сумма изменения</param>
        /// <returns>Исходящий баланс</returns>
        public bool ValidateAmmount(decimal balanceIn, decimal ammountIn) => ammountIn >= balanceIn;
        /// <summary>
        /// Обновить информацию о счете
        /// </summary>
        /// <param name="account">DTO счета</param>
        /// <param name="balance"> Измененный баланс </param>
        public void UpdateAccount(AccountDto account, decimal balance)
        {
            var accountModel = new AccountModel(account.Id, account.AccountNumber, balance, account.AccountType);
            _accountRepository.Update(accountModel);
        }
        /// <summary>
        /// Создание DTO ответа по результату транзакции между двумя сччетами для передачи во внешние системы
        /// </summary>
        /// <param name="result">DTO для передачи счетов</param>
        /// <returns>DTO успешного ответа</returns>
        public ResponseOkDto<TransactionDto> FormResponseForCreateEntryTransaction(TransactionDto result) => new ResponseOkDto<TransactionDto>
        {
            Status = "Ok",
            Result = result
        };
        /// <summary>
        /// Создание DTO ответа по результату транзакции между двумя сччетами для передачи во внешние системы
        /// </summary>
        /// <param name="result">DTO для передачи счетов</param>
        /// <returns>DTO успешного ответа</returns>
        public ResponseOkDto<AccountTransferDto> FormResponseForCreateEntrySolo(AccountTransferDto result) => new ResponseOkDto<AccountTransferDto>
        {
            Status = "Ok",
            Result = result
        };
        /// <summary>
        /// Создание DTO неудачных запросов или ситемных сообщений
        /// </summary>
        /// <param name="status">Статус запроса</param>
        /// <param name="message">Сообщение</param>
        /// <returns></returns>
        public ResponseMessageDto FormMessageResponse(string status, string message) => new ResponseMessageDto
        {
            Status = status,
            Message = message
        };
        /// <summary>
        /// Сохранение нового счета и получения его идентификатора
        /// </summary>
        /// <param name="account">DTO счета</param>
        /// <param name="balance">Баланс счета</param>
        /// <returns></returns>
        public async Task<Guid> SaveAccount(AccountDto account, decimal balance)
        {
            var accountModel = new AccountModel(account.AccountNumber, balance, account.AccountType);
            await _accountRepository.AddAccount(accountModel);
            return accountModel.Id;
        }
        /// <summary>
        /// Заполненние полей нового счета  default ных данных 
        /// </summary>
        /// <param name="accountNumber">Номер счета</param>
        /// <param name="accountType">Тип счета</param>
        /// <returns></returns>
        public AccountDto InitiateAccount(string accountNumber, int accountType) => new AccountDto
        {
            AccountNumber = accountNumber,
            AccountType = accountType,
            Balance = 0M
        };
 


    }
}
