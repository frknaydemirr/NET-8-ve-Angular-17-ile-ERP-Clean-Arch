using AutoMapper;
using ERPServer.Application.Features.Customers.CreateCustomer;
using ERPServer.Application.Features.Customers.UpdateCustomer;
using ERPServer.Application.Features.Depots.CreateDepots;
using ERPServer.Application.Features.Depots.UpdateDepots;
using ERPServer.Application.Features.Invoices.CreateInvoice;
using ERPServer.Application.Features.Orders.CreateOrder;
using ERPServer.Application.Features.Orders.UpdataOrder;
using ERPServer.Application.Features.Products.CreateProducts;
using ERPServer.Application.Features.Products.UpdateProducts;
using ERPServer.Application.Features.Recipes.RecipeDetails.CreateRecipeDetail;
using ERPServer.Application.Features.Recipes.RecipeDetails.UpdateRecipeDetail;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Enums;

namespace ERPServer.Application.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<UpdateCustomerCommand, Customer>();
            CreateMap<CreateDepotCommand, Depot>();
            CreateMap<UpdateDepotCommand, Depot>();
            CreateMap<CreateProductCommand, Product>().ForMember(member=>member.Type,options
                =>options.MapFrom(p=>ProductTypeEnum.FromValue(p.TypeValue)));
            //Product -> Type alanı var -> CreateCommandProductdan gelen typı enuma dönüştürüp set ediyor!
            CreateMap<UpdateProductCommand, Product>().ForMember(member => member.Type, options
               => options.MapFrom(p => ProductTypeEnum.FromValue(p.TypeValue)));


            CreateMap<CreateRecipeDetailCommand, RecipeDetail>();
            CreateMap<UpdateRecipeDetailCommand, RecipeDetail>();







            CreateMap<CreateOrderCommand, Order>()
                .ForMember(member => member.Details,
                options =>
                options.MapFrom(p => p.Details.Select(s => new OrderDetail
                {
                    Price = s.Price,
                    ProductId = s.ProductId,
                    Quantity = s.Quantity
                }).ToList()));

            CreateMap<UpdateOrderCommand, Order>().ForMember(member => member.Details, options =>
            options.Ignore());
             



            
            

            CreateMap<CreateInvoiceCommand, Invoice>()
                .ForMember(member=>member.Type,options=>
                options.MapFrom(p=>InvoiceTypeEnum.FromValue(p.Type)))
               .ForMember(member => member.Details,
               options =>
               options.MapFrom(p => p.Details.Select(s => new OrderDetail
               {
                   Price = s.Price,
                   ProductId = s.ProductId,
                   Quantity = s.Quantity,
               }).ToList()));


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