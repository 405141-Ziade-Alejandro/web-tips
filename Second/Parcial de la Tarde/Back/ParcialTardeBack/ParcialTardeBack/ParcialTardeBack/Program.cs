using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ParcialTardeBack.Mappings;
using System.Text;
using ParcialTardeBack.Interfaces;
using ParcialTardeBack.Interfaces.Services;
using ParcialTardeBack.Models;
using ParcialTardeBack.Repos;
using ParcialTardeBack.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oaut2", new OpenApiSecurityScheme
    {
        Description = "Authentication with Bearer scheme",
        In = ParameterLocation.Header,
        Name = "Autorization",
        Type = SecuritySchemeType.ApiKey
    });
}); //inicializa el swagger en la app


builder.Services.AddDbContext<ParcialSociosClubContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDatabase"));
});

//$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
// LOS SCOPEDS
builder.Services.AddScoped<ISocioRepository, SocioRepository>();
builder.Services.AddScoped<ISocioService, SocioService>();
//builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
//builder.Services.AddScoped<IUsuarioService, UsuarioService>();


builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();
    });
});
//validacion
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            "nicoclase@Tup2024nicoclase@Tup2024nicoclase@Tup2024nicoclase@Tup2024nicoclase@Tup2024nicoclase@Tup2024nicoclase@Tup2024")),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

//siempre primero el use Autentication y desp el use autorization
app.UseAuthentication();
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!11111111
app.UseAuthorization();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();