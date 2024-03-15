using System.Globalization;
using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IOC;

public static class AplicationConfigure
{
    public static void RegistrarValidadores(this IServiceCollection services, Assembly assembly)
    {
        ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");
        services.AddValidatorsFromAssembly(assembly);
    }
}