using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Depots.DeleteDepotsById
{
    public sealed record class DeleteDepotByIdComment(
        Guid Id) : IRequest<Result<string>>;

}


