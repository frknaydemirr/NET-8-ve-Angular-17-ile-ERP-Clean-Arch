using ERPServer.Domain.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ERPServer.Application.Features.Invoices.GetAllInvioice
{
    internal sealed class GetAllInvoiceQueryHandler(
      IInvoiceRepository invoiceRepository)
        : IRequestHandler<GetAllInvoiceQuery, List<Invoice>>
    {
        public async Task<List<Invoice>> Handle(GetAllInvoiceQuery request, CancellationToken cancellationToken)
        {
            List<Invoice> invoices = await invoiceRepository.Where(p => p.Type.Value
            == request.Type).OrderBy(p => p.Date)
            .ToListAsync(cancellationToken);

            return invoices;
        }
    }
}
