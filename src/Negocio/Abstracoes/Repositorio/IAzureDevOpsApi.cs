using Negocio.Entidade.Azure;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Abstracoes.Repositorio
{
    public interface IAzureDevOpsApi
    {
        [Get("/_apis/wit/workitems/{id}?api-version=7.1-preview.3")]
        Task<dynamic> GetWorkItemAsync([AliasAs("organization")] string organization, [AliasAs("project")] string project, int id);
    }
}
