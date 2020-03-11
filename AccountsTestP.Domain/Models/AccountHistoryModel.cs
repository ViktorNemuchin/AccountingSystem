using System;

namespace AccountsTestP.Domain.Models
{
    /// <summary>
    /// Модель описания таблицы журнала проводок
    /// </summary>
    public class AccountHistoryModel : BaseModel
    {
        /// <summary>
        /// Id счета списания 
        /// </summary>
        public Guid SourceAccountId { get; private set; }
        /// <summary>
        /// Id счета зачисления
        /// </summary>
        public Guid DestinationAccountId { get; private set; }
        /// <summary>
        /// Баланс счета списания после проведения проводки
        /// </summary>
        public decimal SourceAccountBalance { get; private set; }
        /// <summary>
        /// баланс счета зачисления после проведения проводки
        /// </summary>
        public decimal DestinationAccountBalance { get; private set; }
        /// <summary>
        /// Сумма проводки
        /// </summary>
        public decimal Amount { get; private set; }
        /// <summary>
        /// Id операции
        /// </summary>
        public Guid OperationId { get; private set; }
        /// <summary>
        /// Дата регистрации проводки
        /// </summary>
        public DateTimeOffset CreationDate { get; private set; }
        /// <summary>
        /// Дата влияния на счет проводки
        /// </summary>
        public DateTimeOffset DueDate { get; private set; }
        /// <summary>
        /// Описание проводки
        /// </summary>
        public string Description { get; private set; }
        /// <summary>
        /// Конструктор для заполнения модели таблицы журнала проводки для создания корректирующей проводки 
        /// </summary>
        /// <param name="id">Id проводки</param>
        /// <param name="destinationAccountId">Id счета зачисления</param>
        /// <param name="sourceAccountId">Id счета списания</param>
        /// <param name="amount">Сумма проводки</param>
        /// <param name="sourceAccountBalance">Баланс счета списания после проведения проводки</param>
        /// <param name="destinationAccountBalance">Баланс счета зачисления после проведения проводки</param>
        /// <param name="dueDate">Дата влияния проводки на счет</param>
        /// <param name="description">Описание</param>
        /// <param name="operationId">Id операции</param>
        public AccountHistoryModel(Guid id, Guid destinationAccountId, Guid sourceAccountId, decimal amount, decimal sourceAccountBalance, decimal destinationAccountBalance, DateTimeOffset dueDate, string description, Guid operationId)
        {
            Id = id;
            DestinationAccountId = destinationAccountId;
            SourceAccountId = sourceAccountId;
            Amount = amount;
            DueDate = dueDate;
            Description = description;
            OperationId = operationId;
            SourceAccountBalance = sourceAccountBalance;
            DestinationAccountBalance = destinationAccountBalance;
            CreationDate = new DateTimeOffset(DateTime.Now, TimeSpan.FromHours(3));
        }
        /// <summary>
        /// Конструктор для заполнения модели таблицы журнала проводок 
        /// </summary>
        /// <param name="destinationAccountId">Id счета зачисления</param>
        /// <param name="sourceAccountId">Id счета списания</param>
        /// <param name="amount">Сумма проводки</param>
        /// <param name="sourceAccountBalance">Баланс счета списания после проведения проводки</param>
        /// <param name="destinationAccountBalance">Баланс счета зачисления после проведения проводки</param>
        /// <param name="dueDate">Дата влияния на проводку</param>
        /// <param name="description">Описание проводки</param>
        /// <param name="operationId">Id операции</param>
        public AccountHistoryModel(Guid destinationAccountId, Guid sourceAccountId, decimal amount, decimal sourceAccountBalance, decimal destinationAccountBalance, DateTimeOffset dueDate, string description, Guid operationId)
        {
            DestinationAccountId = destinationAccountId;
            SourceAccountId = sourceAccountId;
            Amount = amount;
            DueDate = dueDate;
            Description = description;
            OperationId = operationId;
            SourceAccountBalance = sourceAccountBalance;
            DestinationAccountBalance = destinationAccountBalance;
            CreationDate = new DateTimeOffset(DateTime.Now, TimeSpan.FromHours(3));
        }
        /// <summary>
        /// Конструктор для заполнения модели таблицы журнала проводок 
        /// </summary>
        /// <param name="sourceAccountId">Id счета списания</param>
        /// <param name="amount">Сумма проводки</param>
        /// <param name="sourceAccountBalance">Баланс счета списания после проведения проводки</param>
        /// <param name="dueDate">Дата влияния на проводку</param>
        /// <param name="description">Описания</param>
        /// <param name="operationId">Id операции</param>
        public AccountHistoryModel(Guid sourceAccountId, decimal amount, decimal sourceAccountBalance, DateTimeOffset dueDate, string description, Guid operationId)
        {
            SourceAccountId = sourceAccountId;
            Amount = amount;
            DueDate = dueDate;
            Description = description;
            OperationId = operationId;
            SourceAccountBalance = sourceAccountBalance;
            CreationDate = new DateTimeOffset(DateTime.Now, TimeSpan.FromHours(3));
        }
        /// <summary>
        /// Конструктор для заполнения модели таблицы журнала проводок
        /// </summary>
        /// <param name="sourceAccountId">Id счета списания</param>
        /// <param name="destinationAccountId">Id счета зачисления</param>
        /// <param name="amount">Сумма проводвки</param>
        /// <param name="destinationAccountBalance">Баланс счета зачисления после проведения проводки</param>
        /// <param name="dueDate">Дата влияния проводки на счет</param>
        /// <param name="operationId">Id операции</param>
        /// <param name="description">Описание</param>
        public AccountHistoryModel(Guid sourceAccountId, Guid destinationAccountId, decimal amount, decimal destinationAccountBalance, DateTimeOffset dueDate,  Guid operationId, string description)
        {
            DestinationAccountId = destinationAccountId;
            SourceAccountId = sourceAccountId;
            Amount = amount;
            DueDate = dueDate;
            Description = description;
            OperationId = operationId;
            DestinationAccountBalance = destinationAccountBalance;
            CreationDate = new DateTimeOffset(DateTime.Now, TimeSpan.FromHours(3));
        }
    }
}
