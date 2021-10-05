using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Data.Entities.Mappings
{
    class EducationContentMap : IEntityTypeConfiguration<EducationContent>
    {
        public void Configure(EntityTypeBuilder<EducationContent> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.EducationId).IsRequired();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(500);
            builder.Property(x => x.CreateDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();

            //////bire çok ilişki "user - Education"
            builder.HasOne<Education>(r => r.Educations)
                .WithMany(s => s.EducationContents)
                .HasForeignKey(s => s.EducationId);

            builder.ToTable("EducationContents");

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.EducationId).HasColumnName("EducationId");
            builder.Property(x => x.Title).HasColumnName("Title");
            builder.Property(x => x.CreateDate).HasColumnName("CreateDate");
            builder.Property(x => x.IsActive).HasColumnName("IsActive");
        }
    }
}
