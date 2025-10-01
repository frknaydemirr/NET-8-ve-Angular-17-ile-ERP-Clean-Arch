using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Products.CreateProducts
{
    public sealed record class CreateProductCommand(
          string Name,
           int TypeValue // UI’dan int gelecek (1=Mamul, 2=YariMamul)
        ) : IRequest<Result<string>>
    {
    }

}
