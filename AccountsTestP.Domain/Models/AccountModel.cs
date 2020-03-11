using System;

namespace AccountsTestP.Domain.Models
{
    /// <summary>
    /// Модель описания таблицы счетов
    /// </summary>
    public class AccountModel : BaseModel
    {
        /// <summary>
        /// Номер счета
        /// </summary>
        public string AccountNumber { get; private set; }
        /// <summary>
        /// Текущий баланс счета
        /// </summary>
        public decimal Balance { get; private set; }
        /// <summary>
        /// Тип счета
        /// </summary>
        public int AccountType { get; private set; }
        /// <summary>
        /// Дата регистрации в системе
        /// </summary>
        public DateTimeOffset CreatedAt { get; private set; } = DateTimeOffset.Now.ToUniversalTime();
        /// <summary>
        /// Конструктор заполнения модели описания таблицы счетов
        /// </summary>
        /// <param name="accountNumber">Номер счета</param>
        /// <param name="balance">Текущий баланс</param>
        /// <param name="accountType">Тип счета</param>
        public AccountModel(string accountNumber, decimal balance, int accountType)
        { 
            AccountNumber = accountNumber;
            Balance = balance;
            AccountType = accountType;
        }
        /// <summary>
        /// Конструктор заполнения модели описания таблицы счетов
        /// </summary>
        /// <param name="id">Id счета</param>
        /// <param name="accountNumber">Номер счета</param>
        /// <param name="balance">баланс</param>
        /// <param name="accountType">Тип счета</param>
        public AccountModel(Guid id, string accountNumber, decimal balance, int accountType)
        {
            Id = id;
            AccountNumber = accountNumber;
            Balance = balance;
            AccountType = accountType;
        }
    }
}
