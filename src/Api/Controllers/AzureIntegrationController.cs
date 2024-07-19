using Microsoft.AspNetCore.Mvc;
using Negocio.Abstracoes.Repositorio;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AzureIntegrationController : Controller
    {
        private readonly IAzureDevOpsService _azureDevOpsService;

        public AzureIntegrationController(IAzureDevOpsService azureDevOpsService)
        {
            _azureDevOpsService = azureDevOpsService;
        }
        [HttpGet("GetWorkItem/{organization}/{project}/{id}")]
        public async Task<IActionResult> GetWorkItem(string organization, string project, int id)
        {
            var workItem = await _azureDevOpsService.GetWorkItemAsync(organization, project, id);
            return Ok(workItem);
        }

    }
}


    
