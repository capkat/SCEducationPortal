using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCEducationPortal.Data.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Data.Entities.Mappings
{
    public class EducationMap : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(500);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.CreateDate).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.Quota);

            ////bire çok ilişki "user - Education"
            builder.HasOne<AppUser>(r => r.User)
                .WithMany(s => s.Educations)
                .HasForeignKey(s => s.UserId);

            builder.HasOne<Category>(r => r.Category)
                .WithMany(s => s.Educations)
                .HasForeignKey(s => s.CategoryId);

            builder.ToTable("Educations");

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Title).HasColumnName("Title");
            builder.Property(x => x.IsActive).HasColumnName("IsActive");
            builder.Property(x => x.CreateDate).HasColumnName("CreateDate");
            builder.Property(x => x.Description).HasColumnName("Description");
            builder.Property(x => x.Quota).HasColumnName("Quota");


        }
    }
}
