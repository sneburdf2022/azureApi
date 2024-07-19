using Api.Dto;
using Microsoft.AspNetCore.Mvc;
using Negocio.Abstracoes.Servico;
using Negocio.Entidade;
using System.Net;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AzureIntegrationController : Controller
    {
        private readonly IAzureServico _azureServico;
        public AzureIntegrationController(IAzureServico azureServico)
        {
            _azureServico = azureServico;
        }
        [HttpGet("GetWorkItem/{organization}/{project}/{id}")]
        public async Task<IActionResult> GetWorkItemDynamic(string organization, string project, int id)
        {
            dynamic workItem = await _azureServico.GetWorkItensDynamic(organization, project, id);

            return Ok(workItem);
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateWorkItem([FromBody] CreateWorkItem input)
        {
            try
            {
                var result = await _azureServico.PostDataAsync(input);
                return Ok(result);
            }
            catch (HttpRequestException ex)
            {             
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Error occurred: {ex.Message}");
            }
        }
    }
}


    
