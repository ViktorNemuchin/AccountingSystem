using System;
using System.Collections.Generic;
using System.Text;

namespace AccountsTestP.Domain.Dtos
{
    /// <summary>
    /// DTO для обработки входящего JSON для получения отчетов 
    /// </summary>
    public class ReportDateDto
    {
        /// <summary>
        /// Отчетная дата
        /// </summary>
        public DateTimeOffset Date { get; set; }
    }
}
