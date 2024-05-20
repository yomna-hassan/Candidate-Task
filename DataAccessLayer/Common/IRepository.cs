using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Common
{
     public   interface IRepository<TEntity> where TEntity : class
    {
         Task<TEntity> Add(TEntity entity);
         Task<TEntity> Update(TEntity entity);
    }
}
