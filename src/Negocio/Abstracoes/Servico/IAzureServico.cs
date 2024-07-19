using Negocio.Entidade.Azure;

namespace Negocio.Abstracoes.Servico
{
    public interface IAzureServico
    {
        Task<WorkItem> GetAsyncWorkItem(string organization, string project, int id);
        Task<WorkItem> CreateWorkItemAsync(string organization, string project, WorkItem workitem);

    }
}
