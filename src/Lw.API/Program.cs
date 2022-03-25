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
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.JsonSerializerOptions.IgnoreNullValues = true;
});

builder.Services
    .AddScoped<ITranslationService, TranslationService>()
    .AddScoped<ITranslationRepository, TranslationRepository>();

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfiles)));

builder.Services.AddDbContext<ApiDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("db")));

var app = builder.Build();

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
