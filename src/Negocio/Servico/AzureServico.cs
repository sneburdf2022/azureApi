using Microsoft.Extensions.Options;
using Negocio.Abstracoes.Servico;
using Negocio.Entidade;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Negocio.Servico
{
    public class AzureServico: IAzureServico
    {
        private string _urlAzure;       
        private readonly IOptionsMonitor<ApiConfig> _apiConfig;
        private readonly HttpClient _httpClient;


        public AzureServico(IOptionsMonitor<ApiConfig> apiConfig, HttpClient httpClient)
        {
            _apiConfig = apiConfig;
            _urlAzure = _apiConfig.CurrentValue.UrlAzure;
            _httpClient = httpClient;
            var token = _apiConfig.CurrentValue.UserToken;
            var autentication =Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "", token)));
            // Adiciona a autenticação básica
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", autentication);
        }
         public async Task<dynamic> GetWorkItensDynamic(string oragnizacao, string projeto, int id)
        {
            var response = await _httpClient.GetAsync($"{_urlAzure}/{oragnizacao}/{projeto}/_apis/wit/workitems/{id}?api-version=7.1-preview.3");
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            var workItem = System.Text.Json.JsonSerializer.Deserialize<dynamic>(jsonString, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true
            });
            return workItem;
        }
        public async Task<dynamic> PostDataAsync(CreateWorkItem input)
        {
            var dadosWorkItem = CriarDados(input);
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(dadosWorkItem), Encoding.UTF8, "application/json-patch+json");
            //var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(input));
            var response = await _httpClient.PostAsync($"{_urlAzure}/{input.oranizacao}/{input.projecto}/_apis/wit/workitems/${input.tipo}?api-version=7.1-preview.3", content);
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            var workItem = System.Text.Json.JsonSerializer.Deserialize<dynamic>(jsonString, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true
            });
            return workItem;
        }
        private List<ItemIncluir> CriarDados(CreateWorkItem input)
        {
            var dadosWorkItem = new List<ItemIncluir>();
            dadosWorkItem.Add(new ItemIncluir() { op = "add", from= null,path = "/fields/System.Title",value = input.titulo });
            dadosWorkItem.Add(new ItemIncluir() { op = "add", from = null, path = "/fields/System.Description", value = "<div>" + input.descicao + "</div>" });
            return dadosWorkItem;
        }

    }
}
