using ERPServer.Domain.Entities;
using ERPServer.Domain.Repository;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Depots.DeleteDepotsById
{
    internal sealed class DeleteByIdCommandHandler(
     IDepotRepository depotRepository,
     IUnitOfWork unitOfWork    ) : IRequestHandler<DeleteDepotByIdComment, Result<string>>

    {


        public async Task<Result<string>> Handle(DeleteDepotByIdComment request, CancellationToken cancellationToken)
        {

            Depot depot = await depotRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);

            if (depot is null)
            {
                return Result<string>.Failure("Depo Bulunamadı!");
            }
            depotRepository.Delete(depot);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Depo başarıyla  Silindi!";
        }
    }

}


