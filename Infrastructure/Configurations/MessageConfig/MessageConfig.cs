using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.MessageConfig
{
    public class MessageConfig : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {

            builder.HasOne(x => x.Receiver)
                         .WithMany()
                         .HasForeignKey(x => x.ReceiverId)
                         .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.Sender)
                         .WithMany()
                         .HasForeignKey(x => x.SenderId)
                         .OnDelete(DeleteBehavior.Restrict);


        }
    }
}



