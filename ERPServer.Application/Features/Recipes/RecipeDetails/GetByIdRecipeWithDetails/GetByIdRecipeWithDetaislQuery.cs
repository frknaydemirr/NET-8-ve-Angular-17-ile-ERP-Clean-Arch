using ERPServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Recipes.RecipeDetails.GetByIdRecipeWithDetails
{
    public sealed record class GetByIdRecipeWithDetaislQuery(
        Guid Id ) :IRequest<Result<Recipe>>;
}
