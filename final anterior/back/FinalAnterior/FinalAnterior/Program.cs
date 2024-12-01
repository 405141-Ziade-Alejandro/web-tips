using System.Reflection;
using System.Text;
using FinalAnterior.Models;
using FinalAnterior.Repository;
using FinalAnterior.Repository.Impl;
using FinalAnterior.Service;
using FinalAnterior.Service.Impl;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RepasoParcialTarde.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//injeccion del context
builder.Services.AddDbContext<ContextDb>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDatabase"));
});



//fluent validator
builder.Services.AddFluentValidation((options)=>
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

//configuration api behavior
// builder.Services.Configure<ApiBehaviorOptions>(options =>
// {
//     options.SuppressModelStateInvalidFilter = true;
// });


//Scoped repos
// builder.Services.AddScoped<IDummyRepository, DummyRepository>();
builder.Services.AddScoped<ISucursalRepository, SucursalRepository>();

//Scoped services
// builder.Services.AddScoped<IDummyService, DummyService>();
builder.Services.AddScoped<ISucursalService, SucursalService>();

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

// app.UseAuthentication();


app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();