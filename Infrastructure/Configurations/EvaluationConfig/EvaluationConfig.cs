using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.EvaluationConfig
{
    internal class EvaluationConfig : IEntityTypeConfiguration<Evaluation>
    {
        public void Configure(EntityTypeBuilder<Evaluation> builder)
        {
            builder.HasOne(x => x.Trainee)
               .WithMany()
               .HasForeignKey(x => x.TraineeId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}


