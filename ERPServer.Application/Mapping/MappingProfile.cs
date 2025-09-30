using AutoMapper;
using ERPServer.Application.Features.Customers.CreateCustomer;
using ERPServer.Application.Features.Customers.UpdateCustomer;
using ERPServer.Domain.Entities;

namespace ERPServer.Application.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<UpdateCustomerCommand, Customer>();
           
        }
    }
}
//Bu sınıf AutoMapper kütüphanesinin bir profili.
//AutoMapper, nesneler arasında otomatik dönüşüm (mapping) yapar.
//CreateCustomerCommand nesnesindeki tüm uygun property'ler (Name, TaxDepartment vb.) otomatik olarak Customer entity’sine kopyalanacak.

//Böylece, manuel olarak her property’yi atamaya gerek kalmaz:

//Customer customer = new Customer();
//customer.Name = command.Name;
//customer.TaxDepartment = command.TaxDepartment;
// vs...
//MappingProfile, Command nesnelerini Entity nesnelerine dönüştürmek için AutoMapper’a yol gösterir.
//Kod tekrarını azaltır ve daha temiz bir yapı sağlar.