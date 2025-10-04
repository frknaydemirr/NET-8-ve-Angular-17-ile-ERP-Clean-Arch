using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPServer.Infrastructure.Configurations
{
    internal sealed class InvoiceDetailConfiguraiton : IEntityTypeConfiguration<InvoiceDetails>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetails> builder)
        {
            builder.HasOne(p => p.Product)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(p => p.Price).HasColumnType("money");

            builder.Property(p => p.Quantity).HasColumnType("decimal(7,2)");
        }
    }


}
