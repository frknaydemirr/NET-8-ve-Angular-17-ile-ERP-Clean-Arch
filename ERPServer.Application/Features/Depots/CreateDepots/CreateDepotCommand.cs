using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Depots.CreateDepots
{
    public sealed record  class CreateDepotCommand(
        string name,
        string city,
        string Town,
        string FullAddress) : IRequest<Result<string>>;
}

