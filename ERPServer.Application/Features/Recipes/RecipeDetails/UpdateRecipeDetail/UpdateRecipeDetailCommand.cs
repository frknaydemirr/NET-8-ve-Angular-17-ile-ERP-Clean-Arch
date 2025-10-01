using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Recipes.RecipeDetails.UpdateRecipeDetail
{
    public sealed  record class UpdateRecipeDetailCommand(
        Guid Id,
        Guid ProductId,
        decimal Quantity) : IRequest<Result<string>>;
}
