using Microsoft.EntityFrameworkCore;
using RecruitmentManager.Entities.Entities;

namespace RecruitmentManager.DataAccess.Context
{
    public class SqlServerContext : DbContext
    {
        private readonly string _connectionString = string.Empty;

        public DbSet<Client> Client { get; set; }
        public DbSet<Recruiter> Recruiter { get; set; } //Silena,Mariana
        public DbSet<HardSkill> HardSkill { get; set; }//Dayhana,Paulina
        public DbSet<SoftSkill> SoftSkill { get; set; }//Dayhana,Paulina
        public DbSet<Interviewer> Interviewer { get; set; }//Dayhana
        public DbSet<FinalReport> FinalReport { get; set; }//Dolcey
        public DbSet<Interview> Interview { get; set; }//Jhonny
        public DbSet<Assessment> Assessment { get; set; }//Santiago
        public DbSet<Vacancy> Vacancy { get; set; }//Sebastian
        public DbSet<Candidate> Candidate { get; set; }//Isabella

        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasKey(c => new { c.IdClient });
            modelBuilder.Entity<Client>().Property(c => c.IdClient).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
            //modelBuilder.Entity<Client>().ToTable("Clients");
            
                modelBuilder.Entity<Recruiter>().HasKey(c => new { c.IdRecruiter });
            modelBuilder.Entity<Recruiter>().Property(c => c.IdRecruiter).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            modelBuilder.Entity<HardSkill>().HasKey(s => new { s.IdHardSkill });
            modelBuilder.Entity<HardSkill>().Property(s => s.IdHardSkill).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            modelBuilder.Entity<SoftSkill>().HasKey(s => new { s.IdSoftSkill });
            modelBuilder.Entity<SoftSkill>().Property(s => s.IdSoftSkill).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            modelBuilder.Entity<Interviewer>().HasKey(i => new { i.IdInterviewer });
            modelBuilder.Entity<Interviewer>().Property(i => i.IdInterviewer).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            modelBuilder.Entity<FinalReport>().HasKey(fr => new { fr.IdReport });
            modelBuilder.Entity<FinalReport>().Property(fr => fr.IdReport).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            modelBuilder.Entity<Interview>().HasKey(c => new { c.IdInterview });
            modelBuilder.Entity<Interview>().Property(c => c.IdInterview).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            modelBuilder.Entity<Assessment>().HasKey(a => new { a.IdAssessment });
            modelBuilder.Entity<Assessment>().Property(c => c.IdAssessment).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            modelBuilder.Entity<Vacancy>().HasKey(v => new { v.IdVacancy });
            modelBuilder.Entity<Vacancy>().Property(v => v.IdVacancy).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            modelBuilder.Entity<Candidate>().HasKey(c => new { c.IdCandidate });
            modelBuilder.Entity<Candidate>().Property(c => c.IdCandidate).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            base.OnModelCreating(modelBuilder);
        }
    }
}
