using Negocio.Entidade;

namespace Negocio.Abstracoes.Servico
{
    public interface IAzureServico
    {        
        Task<dynamic> GetWorkItensDynamic(string oragnizacao, string projeto, int id);
        Task<dynamic> PostDataAsync(CreateWorkItem input);
    }
}
