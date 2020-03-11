using System;
using System.Collections.Generic;
using System.Text;

namespace AccountsTestP.Domain.Dtos
{
    /// <summary>
    /// DTO Передача данных для отчета во внешние сервисы
    /// </summary>
    public class ReportAccountBalanceDto
    {
        /// <summary>
        /// Id счета
        /// </summary>
        public Guid AccountId { get; set; }
        /// <summary>
        /// Баланс на дату
        /// </summary>
        public decimal Balance { get; set; }
        /// <summary>
        /// Дата влияния
        /// </summary>
        public DateTimeOffset DueDate { get; set; }
    }
}
