using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Data.Entities.Mappings
{
    public class EducationContentFileMap : IEntityTypeConfiguration<EducationContentFile>
    {
        public void Configure(EntityTypeBuilder<EducationContentFile> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.EducationContentId).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.CreateDate).IsRequired();
            builder.Property(x => x.FileName).HasMaxLength(3000);
            builder.Property(x => x.FileExtension).HasMaxLength(3000);
            


            builder.HasOne<EducationContent>(r => r.EducationContents)
              .WithMany(s => s.EducationContentFiles)
            .HasForeignKey(s => s.EducationContentId);

            builder.ToTable("EducationContentFiles");

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.EducationContentId).HasColumnName("EducationContentId");
            builder.Property(x => x.IsActive).HasColumnName("IsActive");
            builder.Property(x => x.CreateDate).HasColumnName("CreateDate");
            builder.Property(x => x.FileName).HasColumnName("FileName");
            builder.Property(x => x.FileExtension).HasColumnName("FileExtension");


        }
    }
}
