using ERPServer.Domain.Repository;
using ERPServer.Infrastructure.Context;
using GenericRepository;

namespace ERPServer.Infrastructure.Repository
{
    internal sealed class InvoiceDetailRepository : Repository<InvoiceDetails, ApplicationDbContext>, IInvoiceDetailRepository
    {
        public InvoiceDetailRepository(ApplicationDbContext context) : base(context)
        {
        }
    }



}
