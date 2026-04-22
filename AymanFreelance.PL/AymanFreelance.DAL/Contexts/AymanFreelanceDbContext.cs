using AymanFreelance.DAL.BaseEntity;
using AymanFreelance.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AymanFreelance.DAL.Contexts
{
    public class AymanFreelanceDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AymanFreelanceDbContext(DbContextOptions<AymanFreelanceDbContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<ProfessionTBL> ProfessionTBLs { get; set; } 
        public DbSet<GenderTBL> GenderTBLs { get; set; } 
        public DbSet<CountryTBL> CountryTBLs { get; set; } 
        public DbSet<EmailTBL> EmailTBLs { get; set; } 
        public DbSet<AppErrorTBL> AppErrorTBLs { get; set; }
        public DbSet<UserTypeTBL> UserTypeTBLs { get; set; }
        public DbSet<ProjectTBL> ProjectTBLs { get; set; }
        public DbSet<FreelancerRatingTBL> FreelancerRatingTBLs { get; set; }
        public DbSet<ProjectApplicationTBL> ProjectApplicationTBLs { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        //optionsBuilder.UseSqlServer("server=.; database=AYMDatingDB; trusted_connection = true;");

        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("BDataSchema");
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>().ToTable("Users", "ASecurity");
            modelBuilder.Entity<AppRole>().ToTable("Roles", "ASecurity");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "ASecurity");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "ASecurity");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "ASecurity");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "ASecurity");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "ASecurity");
        }
    }
}
