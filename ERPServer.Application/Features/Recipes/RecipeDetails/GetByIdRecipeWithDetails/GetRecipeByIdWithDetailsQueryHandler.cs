using ERPServer.Domain.Entities;
using ERPServer.Domain.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace ERPServer.Application.Features.Recipes.RecipeDetails.GetByIdRecipeWithDetails
{
    internal sealed class GetRecipeByIdWithDetailsQueryHandler(
        IRecipeRepository recipeRepository
        ) : IRequestHandler<GetRecipeByIdWithDetaislQuery, Result<Recipe>>
    {
        public async Task<Result<Recipe>> Handle(GetRecipeByIdWithDetaislQuery request, CancellationToken cancellationToken)
        {
            Recipe? recipe =
                await recipeRepository
                .Where(p => p.Id == request.RecipeId)
                .Include(p => p.Product)
                .Include(P => P.Details!.OrderBy(p=> p.Product!.Name))
                .ThenInclude(P => P.Product)
                .FirstOrDefaultAsync(cancellationToken);

            if(recipe is null)
            {
                return Result<Recipe>.Failure("Ürüne ait reçete bulunamadı!");
            }
            return recipe;
        }
    }
}
