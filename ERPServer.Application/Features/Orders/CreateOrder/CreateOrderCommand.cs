using AutoMapper;
using ERPServer.Domain.Dtos;
using ERPServer.Domain.Repository;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Orders.CreateOrder
{
    public sealed record  class CreateOrderCommand(
        Guid CustomerId,
        DateOnly Date,
        DateOnly DeliveryDate,
        List<InvoiceDetailDto> Details
        ) : IRequest<Result<string>>;



   
}

