using Marriage.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marriage.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BiodataGeneralInfo> BiodataGeneralInfos { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<DataLookup> DataLookups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserEducation> UserEducations { get; set; }
        public DbSet<PersonalInfo> PersonalInfos { get; set; }
        public DbSet<OccupationalInfo> OccupationalInfos { get; set; }
        public DbSet<BiodataContact> BiodataContacts { get; set; }
        public DbSet<BioSteps> BioSteps { get; set; }
        public DbSet<UserBioStepProgress> UserBioStepProgress { get; set; }
        public DbSet<UserBiodata> UserBiodata { get; set; }

        public DbSet<Division> Divisions { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Upazila> Upazilas { get; set; }
        public DbSet<Union> Unions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserBioStepProgress>()
                .HasIndex(x => new { x.UserId, x.StepId })
                .IsUnique();

            modelBuilder.Entity<UserBiodata>()
           .HasIndex(x => x.BiodataNo)
           .IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}
