using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPServer.Domain.Dtos
{
    public sealed record class OrderDetailDto(
        Guid ProductId,
        decimal Quantity,
        decimal Price
        );

}
