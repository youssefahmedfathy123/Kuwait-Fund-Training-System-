using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.ExcusesConfig
{
    public class ExcusesConfig : IEntityTypeConfiguration<Excuses>
    {
        public void Configure(EntityTypeBuilder<Excuses> builder)
        {
            builder.HasOne(x => x.User)
                           .WithMany()
                           .HasForeignKey(x => x.UserId)
                           .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Attendance)
                           .WithMany()
                           .HasForeignKey(x => x.AttendanceId)
                           .OnDelete(DeleteBehavior.Restrict);
        }
    }
}


