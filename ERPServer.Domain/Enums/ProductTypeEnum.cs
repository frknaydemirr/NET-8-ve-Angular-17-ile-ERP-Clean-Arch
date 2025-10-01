using Ardalis.SmartEnum;

namespace ERPServer.Domain.Enums
{
    public sealed class ProductTypeEnum : SmartEnum<ProductTypeEnum>
    {
        public static readonly ProductTypeEnum Product = new("Mamul", 1);
        public static readonly ProductTypeEnum SemiProduct = new("Yarı Mamul", 2);
        public ProductTypeEnum(string name, int value) : base(name, value)
        {

        }
    }
}
