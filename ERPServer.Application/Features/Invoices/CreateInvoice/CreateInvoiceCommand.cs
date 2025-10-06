using ERPServer.Domain.Dtos;
using ERPServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Invoices.CreateInvoice
{
    public sealed record  class CreateInvoiceCommand(
        Guid CustomerId,
        int Type,
        DateOnly Date,
        string InvoiceNumber,
        List<OrderDetailDto> Details
        ) : IRequest<Result<string>>;
}
