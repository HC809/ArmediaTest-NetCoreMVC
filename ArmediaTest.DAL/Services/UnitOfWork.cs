using ArmediaTest.DAL.Context;
using ArmediaTest.DAL.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmediaTest.DAL.Services
{
    public class UnitOfWork
    {
        private DbTestContext context = new DbTestContext();
        private IDbContextTransaction _objTran;

        private GenericRepository<TUser> userRepository;

        public GenericRepository<TUser> UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new GenericRepository<TUser>(context);
                }
                return userRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void CreateTransaction()
        {
            _objTran = context.Database.BeginTransaction();
        }

        public async Task CreateTransactionAsync()
        {
            _objTran = await context.Database.BeginTransactionAsync();
        }

        public void Commit()
        {
            _objTran.Commit();
        }

        public async Task CommitAsync()
        {
            await _objTran.CommitAsync();
        }

        public void Rollback()
        {
            _objTran.Rollback();
            _objTran.Dispose();
        }

        public async Task RollbackAsync()
        {
            await _objTran.RollbackAsync();
            await _objTran.DisposeAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
