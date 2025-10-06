using ERPServer.Application.Features.Orders.RequirementsPlanningByOrderId;
using ERPServer.Domain.Dtos;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Enums;
using ERPServer.Domain.Repositories;
using ERPServer.Domain.Repository;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

internal sealed class RequirementsPlanningByOrderIdCommandHandler(
    IOrderRepository orderRepository,
    IStockMovementRepository stockMovementRepository,
    IRecipeRepository recipeRepository,
    IUnitOfWork unitOfWork

    ) :
    IRequestHandler<RequirementsPlanningByOrderIdCommand, Result<RequirementsPlanningByOrderIdCommandResponse>>
{
    public async Task<Result<RequirementsPlanningByOrderIdCommandResponse>> Handle(RequirementsPlanningByOrderIdCommand request, CancellationToken cancellationToken)
    {
        Order? order = await orderRepository
            .Where(p => p.Id == request.OrderId)
            .Include(p => p.Details!)
            .ThenInclude(p => p.Product)
            .FirstOrDefaultAsync(cancellationToken);

        if (order is null)
        {
            return Result<RequirementsPlanningByOrderIdCommandResponse>.Failure("Sipariş Bulunamadı!");
        }
        List<ProductDto> uretilmesiGerekenÜrünListesi = new();
        List<ProductDto> requirementsPlanningProducts = new();
        if (order.Details is not null)
        {
            foreach (var item in order.Details)
            {
                var product = item.Product;
                List<StockMovement> movements = await stockMovementRepository
                    .Where(p => p.ProductId == product!.Id)
                    .ToListAsync(cancellationToken);


                decimal stock = movements.Sum(p => p.NumberOfEntries) - movements.Sum(p => p.NumberOfOutputs);

                if (stock < item.Quantity)
                {
                    ProductDto uretilmesiGerekenUrun = new()
                    {
                        Id = item.ProductId,
                        Name = product!.Name,
                        Quantity = item.Quantity - stock
                    };

                    uretilmesiGerekenÜrünListesi.Add(uretilmesiGerekenUrun);
                }
            }


            foreach (var item in order.Details)
            {
                Recipe? recipe =
                await recipeRepository
                .Where(p => p.ProductId == item.ProductId)
                .Include(P => P.Details!)
                .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(cancellationToken);

                if (recipe is not null && recipe.Details is not null)
                {
                 
                        foreach (var detail in recipe.Details)
                        {
                            List<StockMovement> urunMovements = await stockMovementRepository
                                .Where(p => p.ProductId == detail.ProductId)
                                .ToListAsync(cancellationToken);

                            decimal stock = urunMovements.Sum(p => p.NumberOfEntries)
                                          - urunMovements.Sum(p => p.NumberOfOutputs);

                            if (stock < detail.Quantity)
                            {
                                ProductDto ihtiyacOlanUrun = new()
                                {
                                    Id = detail.ProductId,
                                    Name = detail.Product!.Name,
                                    Quantity = detail.Quantity - stock
                                };

                                requirementsPlanningProducts.Add(ihtiyacOlanUrun);
                            }
                        }
                    }
                 

                }
            


           


        }
        requirementsPlanningProducts = requirementsPlanningProducts
             .GroupBy(p => p.Id)
             .Select(g => new ProductDto
             {
                 Id = g.Key,
                 Name = g.First().Name,
                 Quantity = g.Sum(item => item.Quantity)
             }).ToList();
        order.Status = OrderStatusEnum.RequirementsPlanWorked;
        orderRepository.Update(order);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new RequirementsPlanningByOrderIdCommandResponse(DateOnly.FromDateTime(DateTime.Now),
               order.Number +
               "Nolu siparişin ihtiyaç planlaması", requirementsPlanningProducts);
    }
}



















//siparişteki ürünlerin tüm depolardaki adetlerine bakacağım -> eğer yetersiz ise kaç tane üretilmesi ya da alınması
//gerektiğini tespit edeceğiz her bir ürün için gereken ürün reçetesini alıp o ürünlerin tek tek stoklarına bakacağız
//üretilmesi için gereken ürünlerden kaç tanesine ihtiaycımız olduğuınu tespit edip liste olarka döndürecpeiz
//hangi ürünün hangi depoda kaç tane olduğunu tespit etmek için entity oluşturacağız!