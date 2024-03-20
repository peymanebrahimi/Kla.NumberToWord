using FluentValidation;
using Kla.NumberToWord.Application.Extensions;
using Kla.NumberToWord.Application.Features;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Kla.NumberToWord.Application.Behaviours;

public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<ValidatorBehavior<TRequest, TResponse>> _logger;
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidatorBehavior(IEnumerable<IValidator<TRequest>> validators, ILogger<ValidatorBehavior<TRequest, TResponse>> logger)
    {
        _validators = validators;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var typeName = request.GetGenericTypeName();

        _logger.LogInformation("Validating command {CommandType}", typeName);

        var context = new ValidationContext<TRequest>(request);

        var failures = _validators
            .Select(v => v.Validate(context))
            .Where(result => result.Errors.Any())
            .SelectMany(result => result.Errors)
            .ToList();

        if (failures.Any())
        {
            _logger.LogWarning("Validation errors - {CommandType} - Command: {@Command} - Errors: {@ValidationErrors}", typeName, request, failures);

            var errorMessage = "ٍError in validation" + Environment.NewLine;
            foreach (var failure in failures)
            {
                errorMessage += failure.ErrorMessage + Environment.NewLine;
            }
            
            throw new NumberToWordConversionException(errorMessage, new ValidationException("Validation exception", failures));
        }

        return await next();
    }
}
