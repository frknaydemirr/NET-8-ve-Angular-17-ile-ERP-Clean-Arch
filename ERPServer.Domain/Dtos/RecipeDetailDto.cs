namespace ERPServer.Domain.Dtos
{
    public sealed record  class RecipeDetailDto(
        Guid ProductId,
        decimal Quantity
    );

}
