using DataAccessLayer.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationContext dbContext;
        private readonly IDbFactory dbFactory;
        IDbContextTransaction transaction;


        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;

        }

        public void CreateTransaction()
        {
            transaction = DbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
        }

        public void RollBack()
        {
            if (transaction != null)
            {
                transaction.Rollback();
            }
        }
      
        public ApplicationContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public async Task Commit()
        {
           await  DbContext.Commit();
        }
        public void CommitTransaction()
        {
            if (transaction != null)
            {
                transaction.Commit();
            }
        }

        public void Dispose()
        {
            if (transaction != null)
            {
                transaction.Dispose();
            }
            DbContext.Dispose();
        }

        public void SaveChange()
        {
            DbContext.SaveChangesAsync();
        }
    }
}
