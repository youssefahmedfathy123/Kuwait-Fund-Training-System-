using Domain.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.CourcesConfig
{
    public class CourcesConfiguration : IEntityTypeConfiguration<Cource>
    {
        public void Configure(EntityTypeBuilder<Cource> builder)
        {
           

            builder.Property(x => x.Name)
                .HasMaxLength(DomainConsts.MaxNameLength);

            builder.HasOne(x => x.Trainer)
                .WithMany()
                .HasForeignKey(x => x.TrainerId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

           



        }
    }
}


