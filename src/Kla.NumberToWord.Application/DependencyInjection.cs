using FluentValidation;
using Kla.NumberToWord.Application.Behaviours;
using Microsoft.Extensions.DependencyInjection;

namespace Kla.NumberToWord.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services )
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(typeof(ApplicationDependencyInjection).Assembly);
            cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(ApplicationDependencyInjection).Assembly);
        
        return services;
    }
}