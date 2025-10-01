using ERPServer.Domain.Entities;
using ERPServer.Domain.Repository;
using ERPServer.Infrastructure.Context;
using GenericRepository;

namespace ERPServer.Infrastructure.Repository
{
    internal sealed class ProductRepository : Repository<Product, ApplicationDbContext>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
