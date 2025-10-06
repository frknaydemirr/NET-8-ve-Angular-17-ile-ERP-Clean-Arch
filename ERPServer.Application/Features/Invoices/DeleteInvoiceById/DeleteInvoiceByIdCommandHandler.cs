using ERPServer.Domain.Repository;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Invoices.DeleteInvoiceById
{
    internal sealed class DeleteInvoiceByIdCommandHandler(
       IInvoiceRepository invoiceRepository,
       IUnitOfWork unitOfWork
        ) : IRequestHandler<DeleteInvoiceByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteInvoiceByIdCommand request, CancellationToken cancellationToken)
        {
            Invoice invoice = await invoiceRepository.GetByExpressionAsync(p => p.Id == request.Id,
                cancellationToken);

            if (invoice == null)
            {
                return Result<string>.Failure("Fatura bulunamadı!");
                
            }
            invoiceRepository.Delete(invoice);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Fatura Başarıyla Silindi!";
        }
    }
}
