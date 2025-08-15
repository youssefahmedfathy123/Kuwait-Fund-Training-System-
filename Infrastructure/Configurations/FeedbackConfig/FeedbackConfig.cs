using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.FeedbackConfig
{
    internal class FeedbackConfig : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.Cource)
               .WithMany()
               .HasForeignKey(x => x.CourceId)
               .OnDelete(DeleteBehavior.Restrict);



        }
    }
}
