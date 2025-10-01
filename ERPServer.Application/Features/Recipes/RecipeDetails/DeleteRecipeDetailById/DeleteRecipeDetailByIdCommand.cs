using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Recipes.RecipeDetails.DeleteRecipeDetailById
{
    public sealed record  class DeleteRecipeDetailByIdCommand(
        Guid Id ) : IRequest<Result<string>>;
}
