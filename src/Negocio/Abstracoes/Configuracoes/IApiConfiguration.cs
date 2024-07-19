namespace Negocio.Abstracoes.Configuracoes
{
    public interface IApiConfiguration
    {
        public string? UrlAzure { get; }
        public string? UserToken { get; }
        public string? UserAzure { get; }
        public string? BearerToken { get;}
    }
}
