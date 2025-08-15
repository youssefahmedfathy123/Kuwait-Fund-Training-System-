using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.ExamStatusConfig
{
    public class ExamStatusConfig : IEntityTypeConfiguration<ExamStatus>
    {
        public void Configure(EntityTypeBuilder<ExamStatus> builder)
        {
            builder.HasOne(x => x.Exam)
               .WithMany()
               .HasForeignKey(x => x.ExamId)
               .OnDelete(DeleteBehavior.Restrict);
               

            builder.HasOne(x => x.Trainee)
               .WithMany()
               .HasForeignKey(x => x.TraineeId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Status).HasConversion<string>();

        }
    }
}
