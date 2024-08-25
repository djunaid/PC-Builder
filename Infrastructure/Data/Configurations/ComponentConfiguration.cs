using PCBuilder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configurations
{
    public class ComponentConfiguration : IEntityTypeConfiguration<PCComponent>
    {
        public void Configure(EntityTypeBuilder<PCComponent> builder)
        {
            builder.HasMany(e => e.Tags).WithMany(e=> e.Components).UsingEntity<PCComponentTag>();

            builder.HasMany(e => e.PriceComponent).WithOne(e => e.PCComponent).HasForeignKey(e => e.PCComponentId).IsRequired();

            builder.Property(e => e.SystemTimeStamp).IsConcurrencyToken().IsRowVersion();

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();

            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.SystemTimeStamp).IsConcurrencyToken().IsRowVersion();

            builder.Property(x => x.CreatedBy).HasMaxLength(256).IsUnicode(false);

            builder.Property(x => x.LastModifiedBy).HasMaxLength(256).IsUnicode(false);

            builder.Property(x => x.Created).IsRequired();

            builder.Property(x => x.LastModified);



        }
    }
}
