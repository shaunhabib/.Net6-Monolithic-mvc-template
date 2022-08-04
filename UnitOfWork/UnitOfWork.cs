using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Monolithic_mvc_temp.Context;
using Monolithic_mvc_temp.Models;
using Monolithic_mvc_temp.Repositories;

namespace Monolithic_mvc_temp.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public IGenericRepository<Employee> Employee {get;}
        private bool _disposed;

        public UnitOfWork(ApplicationContext context, IGenericRepository<Employee> employeeRepository)
        {
            _context = context;
            Employee = employeeRepository;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

         protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing) _context.Dispose();
            _disposed = true;
        }


        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTranscationAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            _context.Database.CommitTransactionAsync();
            await Task.CompletedTask;
        }

        public async Task RollbackTransactionAsync()
        {
            _context.Database.RollbackTransactionAsync();
            await Task.CompletedTask;
        }
    }
}