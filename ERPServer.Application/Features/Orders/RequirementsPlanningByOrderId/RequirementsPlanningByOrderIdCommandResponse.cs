using ERPServer.Domain.Dtos;

public sealed record RequirementsPlanningByOrderIdCommandResponse(
    DateOnly Date,
    string Title,
    List<ProductDto> Products);



















//siparişteki ürünlerin tüm depolardaki adetlerine bakacağım -> eğer yetersiz ise kaç tane üretilmesi ya da alınması
//gerektiğini tespit edeceğiz her bir ürün için gereken ürün reçetesini alıp o ürünlerin tek tek stoklarına bakacağız
//üretilmesi için gereken ürünlerden kaç tanesine ihtiaycımız olduğuınu tespit edip liste olarka döndürecpeiz
//hangi ürünün hangi depoda kaç tane olduğunu tespit etmek için entity oluşturacağız!