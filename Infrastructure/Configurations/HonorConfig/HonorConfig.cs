using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations.HonorConfig
{
    public class HonorConfig : IEntityTypeConfiguration<Honor>
    {
        public void Configure(EntityTypeBuilder<Honor> builder)
        {
            builder.HasOne(x => x.Trainee)
               .WithMany()
               .HasForeignKey(x => x.TraineeId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();
        }
    }
}
