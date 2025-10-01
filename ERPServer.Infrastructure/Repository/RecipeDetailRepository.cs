using ERPServer.Domain.Repository;
using ERPServer.Infrastructure.Context;
using GenericRepository;

namespace ERPServer.Infrastructure.Repository
{
    internal sealed class RecipeDetailRepository : Repository<RecipeDetail, ApplicationDbContext>, IRecipeDetailRepository
    {
        public RecipeDetailRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
