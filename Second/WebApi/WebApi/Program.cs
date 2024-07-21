using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(/*options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Authentication with Bearer scheme",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
    });
}*/);
//injeccion del context
// builder.Services.AddDbContext<"contexto va aca">(option =>
// {
//     option.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDatabase"));
// });

//fluent validator
// builder.Services.AddFluentValidation((options)=>
//     options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

//configuration api behavior
// builder.Services.Configure<ApiBehaviorOptions>(options =>
// {
//     options.SuppressModelStateInvalidFilter = true;
// });


//Scoped repos
// builder.Services.AddScoped<IDummyRepository, DummyRepository>();

//Scoped services
// builder.Services.AddScoped<IDummyService, DummyService>();

//Mapper
// builder.Services.AddAutoMapper(typeof(MappingProfile));


//Cors
// builder.Services.AddCors(options =>
// {
//     options.AddDefaultPolicy(policy =>
//     {
//         policy.AllowAnyHeader()
//             .AllowAnyOrigin()
//             .AllowAnyMethod();
//     });
// });

//Jwt authentication
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddJwtBearer(options =>
//     {
//         options.TokenValidationParameters = new TokenValidationParameters
//         {
//             ValidateIssuerSigningKey = true,
//             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("key")),
//             ValidateIssuer = false,
//             ValidateAudience = false
//         };
//     });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// app.UseCors();

// app.UseAuthentication();


// app.UseAuthorization();
app.UseHttpsRedirection();
// app.MapControllers();
app.Run();
