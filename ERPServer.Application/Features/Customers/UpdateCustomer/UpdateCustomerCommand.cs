using ERPServer.Application.Features.Customers.DeleteCustomerById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERPServer.Application.Features.Customers.UpdateCustomer
{
    public sealed partial record UpdateCustomerCommand(
            Guid Id,
           string Name,
            string TaxDepartment,
            string TaxNumber,
            string City,
            string Town,
            string FullAdress) : IRequest<Result<string>>


    {


    }
}
