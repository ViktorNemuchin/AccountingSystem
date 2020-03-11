using System;

namespace AccountsTestP.Domain.Models
{
    /// <summary>
    /// Базовая модель описания таблицы
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// Id таблицы 
        /// </summary>
        public Guid Id { get; set; }
    }
}
