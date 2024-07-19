using Negocio.Entidade;
using Negocio.Recurso;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = builder.Configuration.GetSection("ApiConfiguration");
builder.Services.Configure<ApiConfig>(config);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRegocio();


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
