using Negocio.Entidade.Azure;
using Refit;

namespace Negocio.Abstracoes.Repositorio
{
    public interface IAzureRepositorio
    {
        //[Get("/_apis/wit/workitems/{id}?api-version=7.1-preview.3")]
        [Get("/_apis/wit/workitems/{id}?api-version=7.1-preview.3")]
        [Headers("Content-Type: application/json", "Accept: application/json")]
        Task<WorkItem> GetWorkItemAsync([AliasAs("organization")] string organization, [AliasAs("project")] string project, int id);        

        [Post("/_apis/wit/workitems?api-version=7.1-preview.3")]
        [Headers("Content-Type: application/json", "Accept: application/json")]
        Task<WorkItem> CreateWorkItemAsync([Body] WorkItem workItem);
    }
}
/*
 {
        [Get("/_apis/wit/workitems/{id}?api-version=7.1-preview.3")]
        //[Get("/_apis/wit/workitems/{id}")]
        [Headers("Content-Type: application/json", "Accept: application/json")]
        Task<WorkItem> GetWorkItemAsync(int id);

        [Post("/_apis/wit/workitems?api-version=7.1-preview.3")]
        //[Post("/_apis/wit/workitems")]
        [Headers("Content-Type: application/json", "Accept: application/json")]
        Task<WorkItem> CreateWorkItemAsync([Body] WorkItem workItem);
    }
 */