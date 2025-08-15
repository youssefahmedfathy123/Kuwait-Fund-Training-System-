using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Bi_weeklyReportConfig
{
    public class Bi_weeklyReportConfig : IEntityTypeConfiguration<Bi_weeklyReport>
    {
        public void Configure(EntityTypeBuilder<Bi_weeklyReport> builder)
        {
            builder.HasOne(x => x.User)
                            .WithMany()
                            .HasForeignKey(x => x.UserId)
                            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
