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
            //un strin de connection es la ruta ala DB
            _connectionString = @"Data Source = LTUSPE-L0004\SQLEXPRESS; Initial Catalog = RecruitmentManager; Integrated Security = true;";

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //servidor
            //base de datos
            //modo de seguridad de acceso
            //usuario
            //contrase;a
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {//algunas conf de nuestras entidades
            modelBuilder.Entity<Client>().HasKey(c => new {c.IdClient} );
            modelBuilder.Entity<Client>().Property(c => c.IdClient).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
            modelBuilder.Entity<Candidate>().HasKey(c => new { c.IdCandidate });
            modelBuilder.Entity<Candidate>().Property(c => c.IdCandidate).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            //modelBuilder.Entity<Client>()
            //    .HasOne(c => c.Client)
            //    .WithMany(c => c.Vacancy)
            //    .HasForeignKey(c => c.IdClient);
            base.OnModelCreating(modelBuilder);

        }


        
    }
}
