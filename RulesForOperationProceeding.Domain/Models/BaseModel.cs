using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Models
{
    /// <summary>
    /// Базовый класс модели работы с БД
    /// </summary>
    public abstract class BaseModel
    {

        /// <summary>
        /// Id наследуемого класса
        /// </summary>
        public Guid Id { get; set; }
    }
}
