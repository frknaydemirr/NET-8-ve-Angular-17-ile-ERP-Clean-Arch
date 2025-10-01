using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repository;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Depots.UpdateDepots
{
    internal sealed class UpdateDepotCommandHandler(
        IDepotRepository depotRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper ) : IRequestHandler<UpdateDepotCommand, Result<string>>
        

    {
        public async  Task<Result<string>> Handle(UpdateDepotCommand request, CancellationToken cancellationToken)
        {

            Depot depot = await depotRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);

            if (depot is null)
            {
                return Result<string>.Failure("Depo Bulunamadı!");
            }
            mapper.Map(request, depot);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            //GetByExpressionWithTrackingAsync kullandığımız için -> update metodunu çağırmama gerek yok!

            return "Depo Başarıyla  Güncellendi!";
        }
    }

}
    

