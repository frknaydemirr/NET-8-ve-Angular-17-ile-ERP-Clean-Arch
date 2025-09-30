using ERPServer.Domain.Entities;
using GenericRepository;

namespace ERPServer.Domain.Repository
{
    public  interface IDepotRepository :IRepository<Depot>
    {
    }
}


//IRepository<Depot> nedir?

//Muhtemelen senin projende GenericRepository kütüphanesinden geliyor.

//İçinde CRUD operasyonları (Add, Update, Delete, Get, GetAll, GetByExpression vs.) tanımlı.

//Depot entity’si için generic repository’nin hazır metotlarını kullanmanı sağlıyor.





//3.Adım





