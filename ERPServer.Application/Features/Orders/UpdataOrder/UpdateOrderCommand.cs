using ERPServer.Domain.Dtos;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Orders.UpdataOrder
{
    public sealed record  class UpdateOrderCommand(
        Guid Id,
        Guid CustomerId,
        DateOnly Date,
        DateOnly DeliveryDate,
        List<OrderDetailDto> Details
        ) : IRequest<Result<string>>;
}
