using FluentValidation;

namespace PetShop
{
    public class DogLeashValidator : AbstractValidator<DogLeash>
    {
        public DogLeashValidator()
        {
            RuleFor(d => d.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");

            RuleFor(d => d.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(d => d.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity cannot be negative.");

            RuleFor(d => d.Description)
                .MaximumLength(200).WithMessage("Description cannot exceed 200 characters.");

            RuleFor(d => d.LengthInches)
                .GreaterThan(0).WithMessage("Length must be greater than 0 inches.");

            RuleFor(d => d.Material)
                .NotEmpty().WithMessage("Material is required.");
        }
    }
}
