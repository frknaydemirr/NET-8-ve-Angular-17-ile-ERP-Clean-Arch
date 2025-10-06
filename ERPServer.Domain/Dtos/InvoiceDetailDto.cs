namespace ERPServer.Domain.Dtos
{
    public sealed record class InvoiceDetailDto(
        Guid ProductId,
        Guid DepotId,
        decimal Quantity,
        decimal Price
        );

}
