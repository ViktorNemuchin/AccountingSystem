using Microsoft.EntityFrameworkCore;
using RulesForOperationProceeding.Data.IRepositories;
using RulesForOperationProceeding.Data.RulesForOperationProceedingDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesForOperationProceeding.Data.Repositories
{
    /// <summary>
    /// Класс базовых методов работы с БД
    /// </summary>
    public class BaseRepository: IBaseRepository
    {
        /// <summary>
        /// Экземпляр контекста подключение к БД
        /// </summary>
        protected readonly RulesForOperationProceedingDataDbContext _context;
        /// <summary>
        /// Конструктор класса базовых методов
        /// </summary>
        /// <param name="context">Контекст подключения к БД</param>
        public BaseRepository(RulesForOperationProceedingDataDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(); ;
        }
        /// <summary>
        /// Освобождение ресурсов от подключения к БД и результатлв выполнения методов  
        /// </summary>
        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Сохрание изменений в базе данных синхронно
        /// </summary>
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        /// <summary>
        /// Сохранение изменений в базе данных ассмнхронно
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
                return await _context.SaveChangesAsync();
            }
        }
    }
}
