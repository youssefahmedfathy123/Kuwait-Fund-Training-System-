using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.TrainerConfig
{
    internal class TrainerConfig : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.HasOne(x =>x.Batch)
                .WithMany()
                .HasForeignKey(x => x.BatchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Company)
                .WithMany()
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.User)
              .WithMany()
              .HasForeignKey(x => x.UserId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}





