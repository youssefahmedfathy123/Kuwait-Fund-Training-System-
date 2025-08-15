using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.FineConfig
{
    public class FineConfig : IEntityTypeConfiguration<Fine>
    {
        public void Configure(EntityTypeBuilder<Fine> builder)
        {
            builder.HasOne(x => x.Trainee)
                          .WithMany()
                          .HasForeignKey(x => x.TraineeId)
                          .OnDelete(DeleteBehavior.Restrict);       
        }
    }
}


