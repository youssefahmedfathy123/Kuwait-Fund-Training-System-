using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    internal class LeaveCon : IEntityTypeConfiguration<Leave>
    {
        public void Configure(EntityTypeBuilder<Leave> builder)
        {
            builder.HasOne(x => x.Trainee)
               .WithMany()
               .HasForeignKey(x => x.TraineeId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

