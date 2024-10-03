using FluentValidation;

namespace PetShop
{
    // Validator for general Product properties
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(p => p.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity cannot be negative.");
        }
    }

    // DogLeash-specific validation extending ProductValidator
    public class DogLeashValidator : AbstractValidator<DogLeash>
    {
        public DogLeashValidator()
        {
            Include(new ProductValidator()); // Include base product rules

            RuleFor(d => d.LengthInches)
                .GreaterThan(0).WithMessage("Length must be greater than 0 inches.");

            RuleFor(d => d.Material)
                .NotEmpty().WithMessage("Material is required.");
        }
    }

    // CatFood-specific validation extending ProductValidator
    public class CatFoodValidator : AbstractValidator<CatFood>
    {
        public CatFoodValidator()
        {
            Include(new ProductValidator()); // Include base product rules

            RuleFor(cf => cf.WeightPounds)
                .GreaterThan(0).WithMessage("Weight must be greater than 0 lbs.");
        }
    }
}
