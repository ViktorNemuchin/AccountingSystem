using RulesForOperationProceeding.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Command
{
    /// <summary>
    /// Класс команды обновления правил типа операции
    /// </summary>
    public class UpdateRuleCommand:BaseCommand<ResponseBaseDto>
    {
        /// <summary>
        /// Id правила типа операции
        /// </summary>
        public Guid RuleId { get; private set; }

        /// <summary>
        /// Счет дебета
        /// </summary>
        public string SourceAccount { get; set; }

        /// <summary>
        /// Счет кредита
        /// </summary>
        public string DestinationAccount { get; set; }

        /// <summary>
        /// Порядковый номер правила
        /// </summary>
        public int RuleOrderNumber { get; private set; }

        /// <summary>
        /// Формула вычесления суммы проводки
        /// </summary>
        public string Formula { get; set; }

        /// <summary>
        /// Описание правила 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата начала действия правил операции
        /// </summary>
        public DateTimeOffset DateFrom { get; set; }

        /// <summary>
        /// Id типа операции
        /// </summary>
        public Guid OperationTypeId { get; set; }

        /// <summary>
        /// Конструктор класса изменеия данных правила типа операции
        /// </summary>
        /// <param name="ruleId">Id правила операции </param>
        /// <param name="sourceAccount">Счет дебета</param>
        /// <param name="destinationAccount">Счет кредита</param>
        /// <param name="ruleOrderNumber">Порядковый номер правила</param>
        /// <param name="formula">Формула вычесления суммы проводки</param>
        /// <param name="description">Описание правила</param>
        /// <param name="dateFrom">Дата начала действия правила</param>
        /// <param name="operationTypeId">Id типа операции</param>
        public UpdateRuleCommand(Guid ruleId, string sourceAccount, string destinationAccount,int ruleOrderNumber,  string formula, string description, DateTimeOffset dateFrom, Guid operationTypeId) =>
            (RuleId, SourceAccount, DestinationAccount,RuleOrderNumber, Formula, Description, DateFrom, OperationTypeId) =
            (ruleId, sourceAccount, destinationAccount,ruleOrderNumber, formula, description, dateFrom, operationTypeId);
    }

}
