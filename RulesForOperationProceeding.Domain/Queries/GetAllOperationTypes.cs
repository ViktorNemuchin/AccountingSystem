using System;
using System.Collections.Generic;
using System.Text;
using RulesForOperationProceeding.Domain.DTOS;

namespace RulesForOperationProceeding.Domain.Queries
{
    /// <summary>
    /// Класс запроса на получения всех типов операции
    /// </summary>
    public class GetAllOperationTypes: BaseQuery<ResponseBaseDto>
    {
        /// <summary>
        /// Конструктор класса запроса на получения всех типов операции
        /// </summary>
        public GetAllOperationTypes() { }
    }
}
