using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RulesForOperationProceeding.Data.IRepositories
{
    public interface IBaseRepository
    {
        public Task<int> SaveChangesAsync();

    }
}
