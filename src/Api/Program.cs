using Negocio.Abstracoes.Servico;
using Negocio.Entidade;
using Negocio.Recurso;
using Negocio.Servico;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = builder.Configuration.GetSection("ApiConfiguration");
builder.Services.Configure<ApiConfig>(config);
var apiConfig = config.Get<ApiConfig>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRegocio();
builder.Services.AddHttpClient<IAzureServico, AzureServico>(client =>
{
    //client.BaseAddress = new Uri(apiConfig.UrlAzure);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});


var app = builder.Build();
Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Program>();
            webBuilder.ConfigureLogging((ctx, logging) =>
            {
                logging.AddEventLog(options =>
                {
                    options.SourceName = "Integracao.Azure.Api";
                });
            });
        });
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    //outras configurações
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
