using AutoMapper;
using Lw.API.Filters;
using Lw.DTO.Mappings;
using Lw.Repository;
using Lw.Repository.Repositories;
using Lw.Service.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( options =>
{
    options.OperationFilter<AcceptLanguageFilter>();
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});
// Json response options
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.JsonSerializerOptions.IgnoreNullValues = true;
});

//Depndency injection
builder.Services
    .AddScoped<ITranslationService, TranslationService>()
    .AddTransient<ITranslationRepository, TranslationRepository>();

//Automapper injection
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfiles)));

// DbContext
builder.Services.AddDbContext<ApiDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("db")));

var app = builder.Build();

// Custom Exception Handler
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
app.UseSwagger();
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}
else
{
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lw Exercise API");
        c.RoutePrefix = String.Empty;
    });
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
