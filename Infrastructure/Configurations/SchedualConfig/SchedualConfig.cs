using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.SchedualConfig
{
    public class SchedualConfig : IEntityTypeConfiguration<Schedual>
    {
        public void Configure(EntityTypeBuilder<Schedual> builder)
        {
            builder.HasOne(x => x.Cource)
                .WithMany()
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Group)
                .WithMany()
                .HasForeignKey(x => x.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Day).HasConversion<string>();



        }
    }
}
