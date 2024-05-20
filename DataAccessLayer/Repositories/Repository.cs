using DataAccessLayer.Common;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public  class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private ApplicationContext dataContext;
        private readonly DbSet<TEntity> dbSet;
        protected IDbFactory DbFactory
        {
            get;
            private set;
        }


        protected ApplicationContext DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }


        public Repository(IDbFactory dbFactory) 
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<TEntity>();


        }
        #region Implementation
        public  async Task<TEntity> Add(TEntity entity)
        {
            (entity as BaseEntity).CreationDate = DateTime.Now;
            await dbSet.AddAsync(entity);
           return entity;

        }

        public  async Task<TEntity> Update(TEntity entity)
        {
            var old =await  dbSet.FindAsync((entity as BaseEntity).Id);
            (entity as BaseEntity).CreationDate = (old as BaseEntity).CreationDate;
            dataContext.Entry(old).State = EntityState.Detached;
            (entity as BaseEntity).ModificationDate = DateTime.Now;
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
            return entity;

        }
        #endregion
    }
}
