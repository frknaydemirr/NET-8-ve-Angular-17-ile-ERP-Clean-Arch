using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERPServer.Application.Features.Depots.UpdateDepots
{
    public sealed record UpdateDepotCommand(
        Guid Id,
        string name,
        string city,
        string Town,
        string FullAddress
        ) : IRequest<Result<string>>;

}
    

