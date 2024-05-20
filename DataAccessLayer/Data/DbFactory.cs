using DataAccessLayer.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class DbFactory : Disposable,IDbFactory 
    {
        private ApplicationContext applicationContext;

        private readonly IConfiguration Config;
        public DbFactory(IConfiguration configuration)
        {
            Config = configuration;
        }
        public ApplicationContext Init()
        {
            return applicationContext ?? (applicationContext = CreateDbContext());
        }

        protected override void DisposeCore()
        {
            if (applicationContext != null)
                applicationContext.Dispose();
        }
        public ApplicationContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            optionsBuilder.UseSqlServer(Config.GetConnectionString("DefaultConnection"));

            return new ApplicationContext(optionsBuilder.Options);
        }

  
    }
}
