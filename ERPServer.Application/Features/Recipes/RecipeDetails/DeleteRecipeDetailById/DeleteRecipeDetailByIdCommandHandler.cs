using ERPServer.Domain.Repository;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Recipes.RecipeDetails.DeleteRecipeDetailById
{
    internal sealed class DeleteRecipeDetailByIdCommandHandler(
        IRecipeDetailRepository resipeDetailRepository,
        IUnitOfWork unitOfWork ) : IRequestHandler<DeleteRecipeDetailByIdCommand, Result<string>>
       
    {
        public async Task<Result<string>> Handle(DeleteRecipeDetailByIdCommand request, CancellationToken cancellationToken)
        {
            RecipeDetail recipeDetail = await resipeDetailRepository.GetByExpressionAsync(p => p.Id == request.Id,
                cancellationToken);

            if(recipeDetail is null)
            {
                return Result<string>.Failure("Reçetede bu  ürün Bulunamadı!");
            }
            resipeDetailRepository.Delete(recipeDetail);
            await unitOfWork.SaveChangesAsync();
            return "Ürün Reçeteden Baraşıyla Silindi!";
        }
    }
}
