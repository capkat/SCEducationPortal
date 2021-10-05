using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCEducationPortal.Data.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Data.Entities.Mappings
{
    public class EducationUserMap : IEntityTypeConfiguration<EducationUser>
    {
        public void Configure(EntityTypeBuilder<EducationUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.EducationId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.Createdate).IsRequired();

            builder.ToTable("EducationUsers");

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.UserId).HasColumnName("UserId");
            builder.Property(x => x.EducationId).HasColumnName("EducationId");
            builder.Property(x => x.Createdate).HasColumnName("Createdate");



        }
    }
}
