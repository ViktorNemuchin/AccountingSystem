using RulesForOperationProceeding.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Command
{
    /// <summary>
    /// Класс команды добавления типа операции
    /// </summary>
    public class AddOperationTypeCommand: BaseCommand<ResponseBaseDto>
    {
        /// <summary>
        /// Название типа операции
        /// </summary>
        public string TypeName { get; private set; }
        
        /// <summary>
        /// Список правил типа операции
        /// </summary>
        public List<TransferRuleDto> Rules { get; private set; }

        /// <summary>
        /// Список параметров 
        /// </summary>
        public List<TransferOperationParameterDto> Parameters { get; private set; }

        /// <summary>
        /// Дата начала действия 
        /// </summary>
        public DateTimeOffset DateFrom { get; private set; }

        /// <summary>
        /// Конструктор класса команд добавления типа операции
        /// </summary>
        /// <param name="typeName">Название типа операции</param>
        /// <param name="rules">Список правил</param>
        /// <param name="parameters">Список параметров</param>
        /// <param name="dateFrom">Дата начала действия типа операции</param>
        public AddOperationTypeCommand(string typeName, List<TransferRuleDto> rules, List<TransferOperationParameterDto> parameters, DateTimeOffset dateFrom) => 
            (TypeName, Rules,Parameters, DateFrom) = (typeName, rules, parameters, dateFrom);

    }
}
