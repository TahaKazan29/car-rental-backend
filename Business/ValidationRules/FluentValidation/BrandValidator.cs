using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Image).NotEmpty();
        }
    }
}