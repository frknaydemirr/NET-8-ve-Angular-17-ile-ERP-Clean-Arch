using ERPServer.Domain.Repositories;
using MediatR;
using System.Collections.Generic;
using TS.Result;

namespace ERPServer.Application.Features.Orders.RequirementsPlanningByOrderId
{
    public sealed record  class RequirementsPlanningByOrderIdCommand(
        Guid OrderId) : IRequest<Result<RequirementsPlanningByOrderIdCommandResponse>>;

}



















//siparişteki ürünlerin tüm depolardaki adetlerine bakacağım -> eğer yetersiz ise kaç tane üretilmesi ya da alınması
//gerektiğini tespit edeceğiz her bir ürün için gereken ürün reçetesini alıp o ürünlerin tek tek stoklarına bakacağız
//üretilmesi için gereken ürünlerden kaç tanesine ihtiaycımız olduğuınu tespit edip liste olarka döndürecpeiz
//hangi ürünün hangi depoda kaç tane olduğunu tespit etmek için entity oluşturacağız!