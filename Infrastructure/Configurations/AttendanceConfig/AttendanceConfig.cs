using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.AttendanceConfig
{
    public class AttendanceConfig : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.Property(x => x.Status).HasConversion<string>();
            builder.HasOne(a => a.Trainee)
                .WithMany()
                .HasForeignKey(a => a.TraineeId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(a => a.Schedual)
                .WithMany()
                .HasForeignKey(a => a.SchedualId)
                .OnDelete(DeleteBehavior.Restrict);



        }
    }
}

