using FluentValidation;
using Kla.NumberToWord.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Kla.NumberToWord.Application.Features;

public class NumberToWordQueryValidator : AbstractValidator<ConvertNumberToWordQuery>
{
    private readonly IServiceProvider _serviceProvider;

    public NumberToWordQueryValidator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        RuleFor(x => x.Input).NotEmpty().WithMessage("The input cannot be empty");
        RuleFor(x => x.Input).MaximumLength(14).WithMessage("Maximum length exceeded");
        RuleFor(x => x.Input).Must(BeAcceptableCharacters).WithMessage("Input contains non acceptable character");
    }

    private bool BeAcceptableCharacters(string value)
    {
        var dividerOption = _serviceProvider.GetRequiredService<DividerOption>();
        foreach (var c in value)
        {
            if (!char.IsNumber(c) &&
                c != dividerOption.DecimalSeparator &&
                c != dividerOption.ThousandSeparator)
            {
                return false;
            }
        }
        return true;
    }
}