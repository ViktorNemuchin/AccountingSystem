using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Models
{
    /// <summary>
    /// Класс модели описывающей схему таблицы правил для типа операции
    /// </summary>
    public class RulesModel : BaseModel
    {
        /// <summary>
        /// Счет дебета
        /// </summary>
        public string SourceAccount { get; private set; }

        /// <summary>
        /// Счет кредита
        /// </summary>
        public string DestinationAccount { get; private set; }

        /// <summary>
        /// Формула для вычисления суммы проводки
        /// </summary>
        public string Formula { get; private set; }

        /// <summary>
        /// Описание правила
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Id типа операции
        /// </summary>
        public Guid OperationTypeId { get; private set; }

        /// <summary>
        /// Порядковый номер правила в списке для типа операции
        /// </summary>
        public int RuleOrderNumber { get; private set; }

        /// <summary>
        /// Дата начала действия правила
        /// </summary>
        public DateTimeOffset DateFrom { get; private set; }

        /// <summary>
        /// Конструктор класса модели описывающей схему таблицы правил для типа операции для удаления или изменения записи
        /// </summary>
        /// <param name="id">Id правила</param>
        /// <param name="sourceAccount">Счет дебета</param>
        /// <param name="destinationAccount">Счет кредита</param>
        /// <param name="ruleOrderNumber">Порядковый номер правила в списке для типа операции</param>
        /// <param name="formula">Формула для вычисления суммы проводки</param>
        /// <param name="description">Описание правила</param>
        /// <param name="dateFrom">Дата начала действия правила</param>
        /// <param name="operationTypeId">Id типа операции</param>
        public RulesModel(Guid id, string sourceAccount, string destinationAccount,int ruleOrderNumber, string formula, string description,DateTimeOffset dateFrom, Guid operationTypeId) =>
            (Id, SourceAccount, DestinationAccount,RuleOrderNumber, Formula, Description,DateFrom, OperationTypeId) = 
            (id, sourceAccount, destinationAccount,ruleOrderNumber, formula, description, dateFrom, operationTypeId);

        /// <summary>
        /// Конструктор класса модели описывающей схему таблицы правил для типа операции для добавления записи
        /// </summary>
        /// <param name="sourceAccount">Счет дебета</param>
        /// <param name="destinationAccount">Счет кредита</param>
        /// <param name="ruleOrderNumber">Порядковый номер правила в списке для типа операции</param>
        /// <param name="formula">Формула для вычисления суммы проводки</param>
        /// <param name="description">Описание правила</param>
        /// <param name="dateFrom">Дата начала действия правила</param>
        /// <param name="operationTypeId">Id типа операции</param>
        public RulesModel(string sourceAccount, string destinationAccount,int ruleOrderNumber, string formula, string description, DateTimeOffset dateFrom, Guid operationTypeId) =>
            (SourceAccount, DestinationAccount,RuleOrderNumber, Formula, Description, DateFrom, OperationTypeId) =
            (sourceAccount, destinationAccount,ruleOrderNumber, formula, description, dateFrom, operationTypeId);
    }
}
