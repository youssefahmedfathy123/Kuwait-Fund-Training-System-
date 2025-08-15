using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.End_of_3phasesReportConfig
{
    public class End_of_3phasesReportConfig : IEntityTypeConfiguration<End_of_3phasesReport>
    {
        public void Configure(EntityTypeBuilder<End_of_3phasesReport> builder)
        {
            builder.HasOne(x => x.Trainee)
                            .WithMany()
                            .HasForeignKey(x => x.TraineeId)
                            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}


