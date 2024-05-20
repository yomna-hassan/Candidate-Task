using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Common
{
    public interface IUnitOfWork
    {
        void CreateTransaction();
         Task Commit();
        void CommitTransaction();
        void RollBack();
        void Dispose();
    }
}
