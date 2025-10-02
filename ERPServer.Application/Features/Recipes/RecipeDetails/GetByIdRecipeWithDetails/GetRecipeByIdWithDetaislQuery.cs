using ERPServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Recipes.RecipeDetails.GetByIdRecipeWithDetails
{
    public sealed record class GetRecipeByIdWithDetaislQuery(
        Guid RecipeId ) :IRequest<Result<Recipe>>;
}
