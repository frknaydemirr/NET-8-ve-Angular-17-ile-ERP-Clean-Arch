using ERPServer.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPServer.Infrastructure.Configurations
{
    internal sealed class InvoiceConfiguraiton : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {

            builder.Property(p => p.Type)
                .HasConversion(status => status.Value,
                value => InvoiceTypeEnum.FromValue(value));
        }
    }


}
