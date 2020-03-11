using AccountsTestP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountsTestP.Data.IRepositories
{
    /// <summary>
    /// Класс методов взаимодействия с таблицей хранения бдущих проводок
    /// </summary>
    public interface IAccountHistoryBufferRepository:IRepository<BufferForFutureEntriesDatesModel>
    {
        /// <summary>
        /// Добавление записи в таблицу хранения будущих проводок  
        /// </summary>
        /// <param name="bufferEntry">Запись в таблицу</param>
        /// <returns></returns>
        Task AddBufferEntry(BufferForFutureEntriesDatesModel bufferEntry);
        /// <summary>
        /// Получение всех записей о будущих проводках из журнала
        /// </summary>
        /// <returns>Список будущих проводок</returns>
        Task<List<BufferForFutureEntriesDatesModel>> GetAllBufferEntry();
        /// <summary>
        /// Получение всех записей о будущих проводках на указанную дату
        /// </summary>
        /// <param name="date">Дата и время</param>
        /// <returns>Список будущих проводок на дату</returns>
        Task<List<BufferForFutureEntriesDatesModel>> GetBufferEntryForPeriod(DateTime date);
    }
}
