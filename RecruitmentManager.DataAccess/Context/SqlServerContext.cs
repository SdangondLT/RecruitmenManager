using Microsoft.EntityFrameworkCore;
using RecruitmentManager.Entities.Entities;

namespace RecruitmentManager.DataAccess.Context
{
    public class SqlServerContext : DbContext
    {
        private readonly string _connectionString = string.Empty;

        public DbSet<Client> Client { get; set; }

        public DbSet<HardSkill> HardSkill { get; set; }

        public DbSet<SoftSkill> SoftSkill { get; set; }

        public DbSet<Interviewer> Interviewer { get; set; }

        public SqlServerContext()
        {
            //un strin de connection es la ruta ala DB
            _connectionString = "Data Source = DRM; Initial Catalog = RecruitmentManager; Integrated Security = true";
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
            modelBuilder.Entity<Client>().HasKey(c => new { c.IdClient });
            modelBuilder.Entity<Client>().Property(c => c.IdClient).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            modelBuilder.Entity<HardSkill>().HasKey(s => new { s.IdHardSkill });
            modelBuilder.Entity<HardSkill>().Property(s => s.IdHardSkill).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            modelBuilder.Entity<SoftSkill>().HasKey(s => new { s.IdSoftSkill });
            modelBuilder.Entity<SoftSkill>().Property(s => s.IdSoftSkill).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            modelBuilder.Entity<Interviewer>().HasKey(i => new { i.IdInterviewer });
            modelBuilder.Entity<Interviewer>().Property(i => i.IdInterviewer).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            //modelBuilder.Entity<Client>()
            //    .HasOne(c => c.Client)
            //    .WithMany(c => c.Vacancy)
            //    .HasForeignKey(c => c.IdClient);
            base.OnModelCreating(modelBuilder);

        }


    }
}
