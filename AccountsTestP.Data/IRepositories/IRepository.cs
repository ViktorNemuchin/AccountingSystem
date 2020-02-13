using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AccountsTestP.Domain.Models;

namespace AccountsTestP.Data.IRepositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseModel
    {
        Task<int> SaveChangesAsync();
    }
}
