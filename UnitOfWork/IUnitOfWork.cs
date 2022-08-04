using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Monolithic_mvc_temp.Models;
using Monolithic_mvc_temp.Repositories;

namespace Monolithic_mvc_temp.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Employee> Employee { get; }
        Task<int> SaveChangesAsync();

        Task<IDbContextTransaction> BeginTranscationAsync();

        Task CommitTransactionAsync();

        Task RollbackTransactionAsync();
    }
}