using MediatR;

namespace ERPServer.Application.Features.Invoices.GetAllInvioice
{
    public sealed record  class GetAllInvoiceQuery(
        int Type        ) : IRequest<List<Invoice>>;
}
