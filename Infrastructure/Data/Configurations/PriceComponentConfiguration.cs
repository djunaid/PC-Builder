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
    public class PriceComponentConfiguration : IEntityTypeConfiguration<PriceComponent>
    {
        public void Configure(EntityTypeBuilder<PriceComponent> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Price).HasPrecision(12, 2);

            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.SystemTimeStamp).IsConcurrencyToken().IsRowVersion();

            builder.Property(x => x.CreatedBy).HasMaxLength(256).IsUnicode(false);

            builder.Property(x => x.LastModifiedBy).HasMaxLength(256).IsUnicode(false);

            builder.Property(x => x.Created).IsRequired();

            builder.Property(x => x.LastModified);

            builder.Property(x => x.EffectiveDate).HasColumnType("datetime");

            builder.Property(x => x.ExpriyDate).HasColumnType("datetime").IsRequired(false);

        }
    }
}
