using Microsoft.EntityFrameworkCore;
using RecruitmentManager.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentManager.DataAccess.Context
{
    public class SqlServerContext: DbContext
    {
        private readonly string _connectionString = string.Empty;
        public DbSet<Client> Client { get; set; }

        public DbSet<Assessment> Assessment { get; set; }

        public SqlServerContext()
        {
            _connectionString = @"Data Source = DESKTOP-G2S8F9A\SQLEXPRESS; Initial Catalog = RecruitmentManager; Integrated Security = true; User Id=sa; Password=";

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasKey(c => new {c.IdClient} );
            modelBuilder.Entity<Client>().Property(c => c.IdClient).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            modelBuilder.Entity<Assessment>().HasKey(a => new {a.IdAssessment});
            modelBuilder.Entity<Assessment>().Property(c => c.IdAssessment).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            base.OnModelCreating(modelBuilder);

        }

       
    }
}
