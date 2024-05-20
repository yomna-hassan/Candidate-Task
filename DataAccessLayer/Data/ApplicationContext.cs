using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
     : base(options)
        {

        }

        public DbSet<Candidate> Candidate { get; set; }


        public virtual async Task Commit()
        {
            await SaveChangesAsync();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>().HasKey(t => t.Id);
            modelBuilder.Entity<Candidate>().Property(t => t.FirstName).IsRequired().HasMaxLength(250);              
            modelBuilder.Entity<Candidate>().Property(t => t.LastName).IsRequired().HasMaxLength(250);
            modelBuilder.Entity<Candidate>().Property(t => t.Email).IsRequired().HasMaxLength(250);
            modelBuilder.Entity<Candidate>().Property(t => t.Comment).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
