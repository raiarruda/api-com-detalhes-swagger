using System.Globalization;
using System.Reflection;
using ApiComDetalhes.Contexto;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API de Tarefas para Upskilling Ânima",
        Version = "1.1.0",
        Description = "API para gerenciar tarefas",
        Contact = new OpenApiContact
        {
            Name = "Raissa Arruda",
            Email = "profa.raissaarruda@gmail.com"
        }
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


builder.Services.AddDbContext<BancoDadosContexto>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("conexao"),
        new MySqlServerVersion(new Version(8, 0, 21)));
});

var app = builder.Build();

var cultureInfo = new CultureInfo("pt-BR");
app.UseRequestLocalization(options => options.DefaultRequestCulture = new RequestCulture(cultureInfo));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api tarefas");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
