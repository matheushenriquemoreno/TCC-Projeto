using System.Reflection;
using Application.Interfaces.Mapeamento;

namespace Application.MapingConfig;

public static class ConfigurarMapeamento
{
    public static void Configure(Assembly assembly)
    {
        Type interfaceType = typeof(BaseMapeamento);

        foreach (Type tipo in assembly.GetTypes())
        {
            if (interfaceType.IsAssignableFrom(tipo) && tipo.IsClass && !tipo.IsAbstract)
            {
                try
                {
                    object instancia = Activator.CreateInstance(tipo);

                    MethodInfo metodo = tipo.GetMethod(nameof(BaseMapeamento.Mapear));

                    metodo.Invoke(instancia, null);
                }
                catch (Exception ex)
                {
                    throw new Exception("Necessario vincular um construtor padrão vazio, para as classes de mapeamento");
                }
            }
        }
    }
}
