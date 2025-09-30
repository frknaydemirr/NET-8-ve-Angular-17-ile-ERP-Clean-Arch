using ERPServer.Domain.Entities;
using ERPServer.Domain.Repository;
using ERPServer.Infrastructure.Context;
using GenericRepository;

namespace ERPServer.Infrastructure.Repository
{
    internal sealed class DepotRepository : Repository<Depot,ApplicationDbContext>,IDepotRepository
    {

        public DepotRepository(ApplicationDbContext context) : base(context) { 
        
        
        }

    }
}
////5.Adım