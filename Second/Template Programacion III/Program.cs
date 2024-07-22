using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar el Database Context (Connection String)

/*                              ## EL CONTEXT ACA ##
builder.Services.AddDbContext<TemplateExampleContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
});
*/

// Inyeccion de dependencias de los Repos y Service (Scopeds)

/*                            [Interfaz] -----> [Implementacion]
builder.Services.AddScoped<IEjemploRepository, EjemploRepository>();
builder.Services.AddScoped<IEjemploService, EjemploService>();
*/


// Agregar AutoMapper (MappingProfile)
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Usar CORS
app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();