using RulesForOperationProceeding.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Queries
{
    /// <summary>
    /// Класса запроса на поиск типа операции по его названию  
    /// </summary>
    public class GetOperationTypeByOperationTypeNameQuery:BaseQuery<ResponseBaseDto>
    {
        /// <summary>
        /// Название типа операции
        /// </summary>
        public string OperationTypeName { get; private set; }

        /// <summary>
        /// Конструктор класса запроса на поиск типа операции по его названию
        /// </summary>
        /// <param name="operationTypeName">Название типа операции</param>
        public GetOperationTypeByOperationTypeNameQuery(string operationTypeName) => (OperationTypeName) = (operationTypeName);
    }
}
