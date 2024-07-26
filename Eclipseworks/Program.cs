using DataAcess.Context;
using DataAcess.Interfaces;
using DataAcess.Repository;
using Eclipseworks.AutoMapper;
using Eclipseworks.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    options.JsonSerializerOptions.MaxDepth = 0;
    options.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
    options.JsonSerializerOptions.IgnoreReadOnlyFields = true;
    options.JsonSerializerOptions.IncludeFields = false;
    options.JsonSerializerOptions.WriteIndented = true;
    options.JsonSerializerOptions.WriteIndented = true;
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api EclipseWorks",
        Version = "v1",
        Contact = new OpenApiContact { Email = "cnogueiramatsumura@gmail.com", Name = "Carlos Matsumura" },
        Description = "Api para test EclipseWorks"
    });
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

//builder.Services.AddDbContext<EclipseDBContext>(options => options.UseInMemoryDatabase("EclipsDB"));
var connection = builder.Configuration.GetConnectionString("EclipsDB");
builder.Services.AddDbContext<EclipseDBContext>(options => options.UseSqlServer(connection));
builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));
builder.Services.AddScoped<IProjeto, ProjetoRepository>();
builder.Services.AddScoped<ITarefa, TarefaRepository>();
builder.Services.AddScoped<IPrioridadeTarefa, PrioridadeTarefaRepository>();
builder.Services.AddScoped<IStatusTarefa, StatusTarefaRepository>();
builder.Services.AddScoped<IHistoricoTarefa, HistoricoTarefaRepository>();
builder.Services.AddScoped<IUsuario, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioPerfil, UsuarioPerfilRepository>();
var app = builder.Build();

app.MigrationInitial();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}
else
{
    app.UseHttpsRedirection();
}
app.UseAuthorization();

app.MapControllers();

app.Run();
