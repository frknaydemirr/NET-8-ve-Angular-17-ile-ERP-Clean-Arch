using ERPServer.Domain.Entities;
using ERPServer.Domain.Repository;
using ERPServer.Infrastructure.Context;
using GenericRepository;

namespace ERPServer.Infrastructure.Repository
{
    public sealed class CustomerRepository : Repository<Customer, ApplicationDbContext>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

// Repository -> veritabanına erişim katmanını temsil ediyor.
//Repository<Customer, ApplicationDbContext>

//Burada sen GenericRepository isimli bir paket/kütüphane kullanıyorsun.

//Bu generic repository, Add, Update, Delete, GetById, GetAll gibi ortak CRUD metotlarını zaten içinde barındırıyor.

//Yani tekrar tekrar aynı kodu yazmana gerek kalmıyor.

//Bu interface, CustomerRepository’nin sözleşmesi.

//ICustomerRepository, IRepository<Customer>’den türediği için temel CRUD metotlarını zaten miras alıyor.