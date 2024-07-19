using Microsoft.Extensions.Configuration;
using Negocio.Abstracoes.Configuracoes;

namespace Negocio.Configuracoes
{
    public class ApiConfiguration: IApiConfiguration
    {
        public string? UrlAzure { get; }
        public string? UserToken { get; }
        public string? UserAzure { get; }
        public string? BearerToken { get; }
        public ApiConfiguration(IConfiguration config) {
            UrlAzure = config["UrlAzure"];
            UserToken = config["UserToken"];
            UserAzure = config["UserAzure"];
            BearerToken = config["BearerToken"];
        }
        
    }
}
