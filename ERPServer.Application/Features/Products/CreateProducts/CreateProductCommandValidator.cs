using FluentValidation;

namespace ERPServer.Application.Features.Products.CreateProducts
{
    public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Ürün adı boş olamaz.")
                .MinimumLength(3).WithMessage("Ürün adı en az 3 karakter olmalıdır.");

            RuleFor(p => p.TypeValue)
                .GreaterThan(0).WithMessage("Geçerli bir ürün tipi seçilmelidir.");
        }
    }
}
