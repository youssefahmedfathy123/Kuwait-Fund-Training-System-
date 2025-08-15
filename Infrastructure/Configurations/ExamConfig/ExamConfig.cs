using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.ExamConfig
{
    public class ExamConfig : IEntityTypeConfiguration<Exam>
    {

        public void Configure(EntityTypeBuilder<Exam> builder)
        {

            builder.HasOne(x => x.Cource)
               .WithMany()
               .HasForeignKey(x => x.CourceId)
               .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.Group)
               .WithMany()
               .HasForeignKey(x => x.GroupId)
               .OnDelete(DeleteBehavior.Restrict);
               
        }
    }
}


