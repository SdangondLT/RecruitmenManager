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
        public DbSet<Candidate> Candidate { get; set; }

        public SqlServerContext()
        {
            
            _connectionString = @"Data Source = LTUSPE-L0004\SQLEXPRESS; Initial Catalog = RecruitmentManager; Integrated Security = true;";

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasKey(c => new {c.IdClient} );
            modelBuilder.Entity<Client>().Property(c => c.IdClient).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
            modelBuilder.Entity<Candidate>().HasKey(c => new { c.IdCandidate });
            modelBuilder.Entity<Candidate>().Property(c => c.IdCandidate).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

           
            base.OnModelCreating(modelBuilder);

        }


        
    }
}
