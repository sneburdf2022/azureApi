using Negocio.Entidade;
using Refit;


namespace Persistencia.Azure.Repositorio
{
    public interface IAzureDevOpsApi
    {
        [Get("/_apis/wit/workitems/{id}?api-version=7.1-preview.3")]
        Task<WorkItem> GetWorkItemAsync([AliasAs("organization")] string organization, [AliasAs("project")] string project, int id);

        [Post("/_apis/wit/workitems/{id}?api-version=7.1-preview.3")]
        Task<WorkItem> CreateWorkItemAsync([AliasAs("organization")] string organization, [AliasAs("project")] string project, [Body] WorkItem workItem);
    }
}
