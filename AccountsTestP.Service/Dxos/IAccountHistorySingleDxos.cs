using AccountsTestP.Domain.Command;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountsTestP.Service.Dxos
{
    /// <summary>
    /// Класс методов для преобразования сущности модели записи в журнале проводки в с DTO записи журнала проводки
    /// </summary>
    public interface IAccountHistorySingleDxos
    {
        /// <summary>
        /// Преобразования сущности модели записи в журнале проводки в с DTO записи журнала проводки
        /// </summary>
        /// <param name="entry">Объектов типа модели записи в журнале проводок</param>
        /// <returns>Dto записи журнала проводок</returns>
        public AccountHistoryDto MapAccountHistoryModel(AccountHistoryModel entry);
    }
}
