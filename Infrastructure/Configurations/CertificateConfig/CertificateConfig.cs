using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.CertificateConfig
{
    public class CertificateConfig : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            builder.HasOne(x => x.Trainee)
                           .WithMany()
                           .HasForeignKey(x => x.TraineeId)
                           .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
