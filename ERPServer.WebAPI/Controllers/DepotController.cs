using ERPServer.Application.Features.Customers.CreateCustomer;
using ERPServer.Application.Features.Customers.DeleteCustomerById;
using ERPServer.Application.Features.Customers.GetAllCustomer;
using ERPServer.Application.Features.Customers.UpdateCustomer;
using ERPServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERPServer.WebAPI.Controllers
{

    public sealed class DepotController : ApiController
    {
        public DepotController(IMediator mediator) : base(mediator)
        {
        }
    }
}
