using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Customers.CreateCustomer
{
    //müşteri oluşturma talebilini temsil ediyor:
    public sealed record class CreateCustomerCommand(
            string Name,
            string TaxDepartment,
            string TaxNumber,
            string City,
            string Town,
            string FullAdress
        ) : IRequest<Result<string>>;
    }
//Bu komut bir MediatR request (istek) türüdür.

//İşlendiğinde, Result<string> tipinde bir yanıt dönecek.
//Burada Result genellikle işlemin başarılı olup olmadığını ve mesajını taşır.


//Bu kod bir Command (komut) tanımlıyor. Command,
//CQRS (Command Query Responsibility Segregation) yaklaşımında bir işlemi tetiklemek için kullanılır.