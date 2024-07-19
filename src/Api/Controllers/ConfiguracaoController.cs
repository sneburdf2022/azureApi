using Api.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Negocio.Abstracoes.Servico;
using Negocio.Entidade;
namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfiguracaoController : Controller
    {
        private readonly IOptionsMonitor<ApiConfig> _apiConfig;
        public ConfiguracaoController(IOptionsMonitor<ApiConfig> apiConfig)
        {
            _apiConfig = apiConfig;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var config = _apiConfig.CurrentValue;
            return Ok(config);
        }
    }
}
