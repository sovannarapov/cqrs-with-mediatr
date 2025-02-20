using FluentValidation;
using CQRSWithMediatR.Commands;

namespace CQRSWithMediatR.Validators;

public abstract class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    protected CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Price).GreaterThan(0);
    }
}
