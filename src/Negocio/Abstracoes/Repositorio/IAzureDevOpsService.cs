using Negocio.Entidade.Azure;

namespace Negocio.Abstracoes.Repositorio
{
    public interface IAzureDevOpsService
    {
        Task<WorkItem> GetWorkItemAsync(string organization, string project, int id);
    }
}
