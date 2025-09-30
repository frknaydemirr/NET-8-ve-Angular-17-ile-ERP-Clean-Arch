using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Customers.DeleteCustomerById
{
    public sealed partial record  class DeleteCustomerByIdCommand(
        Guid Id) : IRequest<Result<string>>
        
    {

    }
}
