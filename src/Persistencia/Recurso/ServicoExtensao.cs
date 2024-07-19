using Microsoft.Extensions.DependencyInjection;
using Negocio.Abstracoes.Repositorio;
using Persistencia.Azure.Repositorio;

namespace Persistencia.Azure.Recurso
{
    public static class ServicoExtensao
    {
        public static IServiceCollection AddRepositorios(this IServiceCollection servicos)
        {
            servicos.AddScoped<IAzureRepositorio,AzureRepositorio>();
            return servicos;
        }
    }
}
