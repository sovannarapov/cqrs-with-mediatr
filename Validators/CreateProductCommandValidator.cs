using FluentValidation;
using CQRSWithMediatR.Commands;

namespace CQRSWithMediatR.Validators;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Price).GreaterThan(0);
    }
}
