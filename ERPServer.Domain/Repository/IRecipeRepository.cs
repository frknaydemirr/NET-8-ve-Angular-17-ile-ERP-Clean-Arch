using ERPServer.Domain.Entities;
using GenericRepository;

namespace ERPServer.Domain.Repository
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
    }

}
//İçinde CRUD operasyonları (Add, Update, Delete, Get, GetAll, GetByExpression vs.) tanımlı.