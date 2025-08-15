using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.PreferedCompaniesConfig
{
    public class PreferedCompaniesConfig : IEntityTypeConfiguration<PreferedCompanies>
    {
        public void Configure(EntityTypeBuilder<PreferedCompanies> builder)
        {
            builder.HasOne(x => x.User)
               .WithMany()
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}



