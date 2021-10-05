using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SCEducationPortal.Data.Authentication;
using SCEducationPortal.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Data.Context
{
    public class EducationPortalDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public EducationPortalDbContext(DbContextOptions<EducationPortalDbContext> dbContext) : base(dbContext)
        {
        }

        public DbSet<Education> Educations { get; set; }
        public DbSet<EducationContent> EducationContents { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<EducationContentFile> EducationContentFiles { get; set; }
        public DbSet<EducationUser> EducationUsers { get; set; } 


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EducationPortalDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
