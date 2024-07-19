using Microsoft.Extensions.Options;
using Negocio.Abstracoes.Repositorio;
using Negocio.Abstracoes.Servico;
using Negocio.Entidade;
using Negocio.Entidade.Azure;
using Refit;

namespace Negocio.Servico
{
    public class AzureServico: IAzureServico
    {
        private string _urlAzure;
        private IAzureRepositorio _azureRepositorio;
        private readonly IOptionsMonitor<ApiConfig> _apiConfig;
        private readonly RefitSettings _refitSettings;


        public AzureServico(IOptionsMonitor<ApiConfig> apiConfig)
        {
            _apiConfig = apiConfig;
            _urlAzure = _apiConfig.CurrentValue.UrlAzure;
            //Verificar se vai utilizar bearerToken
            //var token = _apiConfig.CurrentValue.BearerToken;
            //var httpClient = new HttpClient
            //{
            //    BaseAddress = new Uri(_urlAzure)
            //};
            //httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            _refitSettings = new RefitSettings
            {
                CollectionFormat = CollectionFormat.Multi,                                
                HttpMessageHandlerFactory = () => new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true,
                    
                    
                }
            };
            //_azureRepositorio = RestService.For<IAzureRepositorio>(httpClient, refitSettings); //--Caso use BearerToken
            
        }     
        
        public async Task<WorkItem> GetAsyncWorkItem(string organization,string  project, int id)
        {
            _urlAzure = _urlAzure +"/" + organization + "/" + project;
            _azureRepositorio = RestService.For<IAzureRepositorio>(_urlAzure, _refitSettings);
            var retorno = await _azureRepositorio.GetWorkItemAsync(organization, project, id);
            return retorno;
        }
        public async Task<WorkItem> CreateWorkItemAsync(string organization, string project, WorkItem workitem)
        {
            _urlAzure = _urlAzure + "/" + organization + "/" + project;
            _azureRepositorio = RestService.For<IAzureRepositorio>(_urlAzure, _refitSettings);
            var retorno = await _azureRepositorio.CreateWorkItemAsync(workitem);
            return retorno;

        }

    }
}
