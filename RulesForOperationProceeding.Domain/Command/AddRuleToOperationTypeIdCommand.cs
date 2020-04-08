using System;
using System.Collections.Generic;
using System.Text;
using RulesForOperationProceeding.Domain.DTOS;

namespace RulesForOperationProceeding.Domain.Command
{
    /// <summary>
    /// Класс команды добавление правил к типу операции
    /// </summary>
    public class AddRuleToOperationTypeIdCommand : BaseCommand<ResponseBaseDto>
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
        /// Порядковый номер учета правила
        /// </summary>
        public int RuleOrderNumber { get; private set; }

        /// <summary>
        /// Формула вычисления суммы проводки
        /// </summary>
        public string Formula { get; private set; }

        /// <summary>
        /// Описание правила
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Id операции
        /// </summary>
        public Guid OperationId { get; private set; }

        /// <summary>
        /// Дата начала действия правила 
        /// </summary>
        public DateTimeOffset DateFrom { get; private set; }

        /// <summary>
        /// Конструктор класса добавления правила
        /// </summary>
        /// <param name="sourceAccount">Счет дебета</param>
        /// <param name="destinationAccount">Счет кредита</param>
        /// <param name="ruleOrderNumber">Порядковый номер правила </param>
        /// <param name="formula">Формула вычисления суммы проводки</param>
        /// <param name="description">Описание правила</param>
        /// <param name="dateFrom">Дата начала действия правил</param>
        /// <param name="operationTypeId">Id типа операции</param>
        public AddRuleToOperationTypeIdCommand(string sourceAccount, string destinationAccount,int ruleOrderNumber, string formula, string description,DateTimeOffset dateFrom, Guid operationTypeId) =>
            (SourceAccount, DestinationAccount,RuleOrderNumber, Formula, Description,DateFrom, OperationId) = (sourceAccount, destinationAccount,ruleOrderNumber, formula, description, dateFrom, operationTypeId);
    }
}
