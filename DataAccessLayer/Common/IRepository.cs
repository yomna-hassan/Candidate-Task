using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Common
{
     public   interface IRepository<T>
     {
        public Task<T> Create(T obj);
        public void Delete(T obj);
        public void Update(T obj);
        public IEnumerable<T> GetAll();
        public T GetById(int Id);
     }
}
