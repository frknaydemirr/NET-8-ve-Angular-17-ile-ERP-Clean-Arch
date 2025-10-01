using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repository;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Products.CreateProducts
{
    internal sealed class CreateProductCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateProductCommand, Result<string>>



    {
        public async Task<Result<string>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            bool isNameExists = await productRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);
            if (isNameExists)
            {
                return Result<string>.Failure("Ürün Adı daha önce kullanılmış!");
            }
            Product product = mapper.Map<Product>(request);
            await productRepository.AddAsync(product, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Ürün kaydı başarıyla tamamlandı!";

        }

    }

}
