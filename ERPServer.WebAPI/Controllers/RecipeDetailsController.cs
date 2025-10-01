using ERPServer.Application.Features.Recipes.RecipeDetails.CreateRecipeDetail;
using ERPServer.Application.Features.Recipes.RecipeDetails.DeleteRecipeDetailById;
using ERPServer.Application.Features.Recipes.RecipeDetails.GetByIdRecipeWithDetails;
using ERPServer.Application.Features.Recipes.RecipeDetails.UpdateRecipeDetail;
using ERPServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERPServer.WebAPI.Controllers
{
    public sealed class RecipeDetailController : ApiController
    {
        public RecipeDetailController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> GetRecipeByIdWithDetails(GetByIdRecipeWithDetaislQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRecipeDetailCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteById(DeleteRecipeDetailByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateRecipeDetailCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }



    }
}
