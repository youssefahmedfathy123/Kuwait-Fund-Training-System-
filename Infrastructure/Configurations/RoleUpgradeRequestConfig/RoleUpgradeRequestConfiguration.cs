using Domain.Entities;
using Domain.Entities.role;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.RoleUpgradeRequestConfig
{
    public class RoleUpgradeRequestConfiguration : IEntityTypeConfiguration<RoleUpgradeRequest>
    {
        public void Configure(EntityTypeBuilder<RoleUpgradeRequest> builder)
        {

            builder.HasKey(r => r.Id);

            builder.Property(x => x.Status).HasConversion<string>();

            builder
                .HasOne<User>()    
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .IsRequired();
        }

    }
}


