using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Models;
using System.Collections.Generic;

namespace AccountsTestP.Service.Dxos
{
    /// <summary>
    /// Класс методов для преобразования сущности модели записи в журнале проводки в с DTO записи журнала проводки
    /// </summary>
    public interface IAccountHistoryDxos
    {
        /// <summary>
        /// Преобразования списка сущносте1 модели записи в журнале проводки в с DTO записи журнала проводки
        /// </summary>
        /// <param name="entry">Список объектов типа модели записи в журнале проводок</param>
        /// <returns>Список Dto записей в журнале проводок</returns>
        public List<AccountHistoryDto> MapAccountHistoryDto(List<AccountHistoryModel> entry);
    }
}
