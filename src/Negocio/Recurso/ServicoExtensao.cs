﻿using Microsoft.Extensions.DependencyInjection;
using Negocio.Abstracoes.Configuracoes;
using Negocio.Abstracoes.Servico;
using Negocio.Configuracoes;
using Negocio.Servico;

namespace Negocio.Recurso
{
    public static class ServicoExtensao
    {
        public static IServiceCollection AddRegocio(this IServiceCollection servicos)
        {
            servicos.AddScoped<IAzureServico, AzureServico>();            
            servicos.AddSingleton<IApiConfiguration, ApiConfiguration >();
            return servicos;
        }
    }
}
