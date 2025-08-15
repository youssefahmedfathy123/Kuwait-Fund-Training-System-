using Domain.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.BatchConfig
{
    public class BatchConfig : IEntityTypeConfiguration<Batch>
    {
        public void Configure(EntityTypeBuilder<Batch> builder)
        {

            builder.Property(b => b.Name)
                .HasMaxLength(DomainConsts.MaxNameLength);

            builder.Property(x => x.Phase).HasConversion<string>();

        }
    }
}


