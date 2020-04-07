using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RulesForOperationProceeding.Data.IRepositories
{
    /// <summary>
    /// Интерфейс базового класса методов работы с бд 
    /// </summary>
    public interface IBaseRepository
    {
        /// <summary>
        /// Сохранение данных в бд
        /// </summary>
        /// <returns></returns>
        public Task<int> SaveChangesAsync();

    }
}
