using Ardalis.SmartEnum;

namespace ERPServer.Domain.Enums
{
    public sealed class InvoiceTypeEnum : SmartEnum<InvoiceTypeEnum>
    {

        public static readonly InvoiceTypeEnum Purches = new InvoiceTypeEnum("Alış Faturası",1);

        public static readonly InvoiceTypeEnum Sales = new InvoiceTypeEnum("Satış Faturası", 1);
        public InvoiceTypeEnum(string name, int value) : base(name, value)
        {
        }
    }
}
