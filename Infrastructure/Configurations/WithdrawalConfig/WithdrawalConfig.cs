using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.LeaveConfig
{
    public class WithdrawalConfig : IEntityTypeConfiguration<Withdrawal>
    {
        public void Configure(EntityTypeBuilder<Withdrawal> builder)
        {
            builder.HasOne(x => x.User)
                           .WithMany()
                           .HasForeignKey(x => x.UserId)
                           .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
