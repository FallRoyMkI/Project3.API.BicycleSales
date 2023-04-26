
using BicycleSales.API.Models.Product.Request;
using FluentValidation;

namespace BicycleSales.API.Validation
{
    public class ProductValidator : AbstractValidator<ProductAddRequest>
    {
        public ProductValidator()
        {
            RuleFor(request => request.Cost)
                .Must(x => x > 0).WithMessage("Invalid Number!");
        }
    }
}
