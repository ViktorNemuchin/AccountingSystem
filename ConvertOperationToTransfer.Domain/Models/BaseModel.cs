using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertOperationToTransfer.Domain.Models
{
    /// <summary>
    /// Базовая модель
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// Id наследуемого типа операции
        /// </summary>
        public Guid Id { get; set; }
    }
}
