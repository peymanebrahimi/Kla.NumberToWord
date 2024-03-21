using FluentValidation;
using Kla.NumberToWord.Application.Behaviours;
using Kla.NumberToWord.Core;
using Kla.NumberToWord.Core.Data;
using Kla.NumberToWord.Core.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Kla.NumberToWord.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(typeof(ApplicationDependencyInjection).Assembly);
            cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(ApplicationDependencyInjection).Assembly);

        services.AddSingleton<DividerOption>(_ => new DividerOption());
        services.AddSingleton<IWordProvider, WordStore>();
        services.AddScoped<INumberToWordConvertor, NumberToWordConvertor>();

        return services;
    }
}