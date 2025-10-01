using ERPServer.Application.Features.Depots.CreateDepots;
using ERPServer.Application.Features.Depots.DeleteDepotsById;
using ERPServer.Application.Features.Depots.GetAllDepots;
using ERPServer.Application.Features.Depots.UpdateDepots;
using ERPServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERPServer.WebAPI.Controllers
{
    public sealed class DepotsController : ApiController
    {
        public DepotsController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllDepotQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateDepotCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteById(DeleteDepotByIdComment request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateDepotCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

    }
}
