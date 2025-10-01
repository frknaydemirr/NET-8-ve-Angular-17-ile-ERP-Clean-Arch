using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Recipes.RecipeDetails.CreateRecipeDetail
{
    public sealed record class CreateRecipeDetailCommand(
        Guid RecipeId,
        Guid ProductId,
        decimal Quantity) :IRequest<Result<string>>;
}
