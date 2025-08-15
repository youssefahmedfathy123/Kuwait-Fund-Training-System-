using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.TraineeConfig
{
    public class TraineeConfig : IEntityTypeConfiguration<Trainee>
    {
        public void Configure(EntityTypeBuilder<Trainee> builder)
        {

            builder.HasOne(x => x.Group)
               .WithMany()
               .HasForeignKey(x => x.GroupId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Company)
               .WithMany()
               .HasForeignKey(x => x.CompanyId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.User)
               .WithMany()
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.PassStatus).HasConversion<string>();

        }
    }
}
