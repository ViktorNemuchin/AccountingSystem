using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConvertOperationToTransfer.Data.IRepository
{
    public interface IBaseRepository
    {
        public Task<int> SaveChangesAsync();
    }
}
