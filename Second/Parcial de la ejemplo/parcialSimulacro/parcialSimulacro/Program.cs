using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using parcialSimulacro.Mapping;
using parcialSimulacro.Models;
using parcialSimulacro.Repository;
using parcialSimulacro.Repository.Impl;
using parcialSimulacro.Service;
using parcialSimulacro.Service.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextDb>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDatabase"));
});

//fluent validator
builder.Services.AddFluentValidation((options)=>
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

//configuration api behavior
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

//Scoped repos
builder.Services.AddScoped<IAlbanilesRepository, AlbanilesRepository>();
builder.Services.AddScoped<IObrasRepository, ObrasRepository>();
//Scoped services
builder.Services.AddScoped<IParcialService, ParcialService>();

//Mapper
builder.Services.AddAutoMapper(typeof(MappingProfile));


//Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors();

 app.UseAuthorization();

app.UseHttpsRedirection();

 app.MapControllers();

app.Run();