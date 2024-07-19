using Microsoft.Extensions.Options;
using Negocio.Abstracoes.Repositorio;
using Negocio.Entidade;
using Negocio.Entidade.Azure;
using Refit;
using System.Text.Json;

namespace Negocio.Servico
{


    public class AzureDevOpsService : IAzureDevOpsService
    {
        private readonly string _urlAzure;
        private readonly IAzureDevOpsApi _azureDevOpsApi;
        private readonly IOptionsMonitor<ApiConfig> _apiConfig;

        public AzureDevOpsService(IOptionsMonitor<ApiConfig> apiConfig)
        {
            _apiConfig = apiConfig;
            _urlAzure = _apiConfig.CurrentValue.UrlAzure;

            var httpClient = new HttpClient(new AuthenticatedHttpClientHandler())
            {
                BaseAddress = new Uri(_urlAzure)
            };

            _azureDevOpsApi = RestService.For<IAzureDevOpsApi>(httpClient, new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer()
            });
        }

        public async Task<WorkItem> GetWorkItemAsync(string organization, string project, int id)
        {
            return await _azureDevOpsApi.GetWorkItemAsync(organization, project, id);
        }

        private class AuthenticatedHttpClientHandler : DelegatingHandler
        {
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "dgd4gcgdgslxo3mnoktikrwylekmf3ncvcm575rzmy5ygci6r74a");
                var retorno = await base.SendAsync(request, cancellationToken);
                return retorno;
            }
        }
        private async Task<string> AutenticarToken(string token)
        {
            var tokenUrl = "https://app.vssps.visualstudio.com/oauth2/token";
            var clientAssertion = "{your_client_assertion}"; // Isso é gerado com base no seu cliente
            var grantType = "authorization_code";
            var code = "{authorization_code}";
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, tokenUrl);
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", grantType),
                    new KeyValuePair<string, string>("code", code),
                    new KeyValuePair<string, string>("redirect_uri", "{your_redirect_uri}"),
                    new KeyValuePair<string, string>("client_id", "{your_client_id}"),
                    new KeyValuePair<string, string>("client_assertion_type", "urn:ietf:params:oauth:client-assertion-type:jwt-bearer"),
                    new KeyValuePair<string, string>("client_assertion", clientAssertion)
                });
                request.Content = content;

                var response = await httpClient.SendAsync(request);
                var responseString = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(responseString);

                // Agora você pode usar tokenResponse.AccessToken para autenticar suas solicitações
            }
            return "";
        }
    }

}
