using AutoMapper;
using ERPServer.Domain.Repository;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Recipes.RecipeDetails.CreateRecipeDetail
{
    internal sealed class CreateRecipeDetailCommandHandler(
        IRecipeDetailRepository recipeDetailRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper
        ) : IRequestHandler<CreateRecipeDetailCommand, Result<string>>
    {
        //aynı üründe ekleme yaparken eğer ürün mevcutsa ; var olan kaydın üstüne adet ekleyip güncelleme yapması lazım:
        public async Task<Result<string>> Handle(CreateRecipeDetailCommand request, CancellationToken cancellationToken)
        {

            RecipeDetail? recipeDetail = await recipeDetailRepository.
                GetByExpressionWithTrackingAsync(p => p.RecipeId == request.RecipeId && p.ProductId == request.ProductId,
                cancellationToken);
            if(recipeDetail is not null)
            {
                recipeDetail.Quantity += request.Quantity;
            }
            else
            {
                recipeDetail =mapper.Map<RecipeDetail>(request);
                await recipeDetailRepository.AddAsync(recipeDetail,cancellationToken);

               

            }
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Reçeteye ürün kaydı başarıyla tamamlandı!";

        }
    }
}
