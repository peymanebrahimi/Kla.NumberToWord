using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Kla.NumberToWord.Application.Features;

public class NumberToWordQueryValidator: AbstractValidator<ConvertNumberToWordQuery>
{
    public NumberToWordQueryValidator()
    {
        RuleFor(q => q.Input).NotEmpty().WithMessage("The input cannot be empty");
        RuleFor(q => q.Input).MaximumLength(14);
    }
}