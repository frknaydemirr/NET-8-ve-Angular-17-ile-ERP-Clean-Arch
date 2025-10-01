using ERPServer.Domain.Abstractions;
using ERPServer.Domain.Entities;

public sealed class RecipeDetail : Entity
{
    public Guid ProductId { get; set; }

    public Guid RecipeId { get; set; }

    public Product? Product { get; set; }

    public decimal Quantity { get; set; }

}