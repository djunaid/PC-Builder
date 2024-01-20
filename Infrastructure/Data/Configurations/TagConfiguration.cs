using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PCBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();

            builder.Property(x => x.Value).HasMaxLength(250);

            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.SystemTimeStamp).IsConcurrencyToken().IsRowVersion();

            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(256).IsUnicode(false);

            builder.Property(x => x.LastModifiedBy).IsRequired().HasMaxLength(256).IsUnicode(false);

            builder.Property(x => x.Created).IsRequired();

            builder.Property(x => x.LastModified).IsRequired();

        }
    }
}
