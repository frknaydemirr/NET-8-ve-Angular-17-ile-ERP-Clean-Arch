using ERPServer.Domain.Entities;
using ERPServer.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPServer.Infrastructure.Configurations
{
    internal sealed class ProductConfiguraiton : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Type).HasConversion(type =>type.Value, value=>  ProductTypeEnum.FromValue(value));
            //database e value sini kaydet: 
            //db den okursan value yi from value ile enuma dönüştür
        }
    }
}


//ENUMU DATABASE DE MAPLEYEMEYİZ ! BURADA TUTMAMIZ LAZIM!
