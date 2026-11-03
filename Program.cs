using GestorProductosApi.Repositories;
using GestorProductosApi.Services;

var builder = WebApplication.CreateBuilder(args);

// ---------------------------------------------------------------
// Registramos los controladores con soporte para DataAnnotations
// ---------------------------------------------------------------
builder.Services.AddControllers();

// ---------------------------------------------------------------
// Inyección de Dependencias:
// Cada petición HTTP que llegue tendrá su propia instancia (Scoped).
// Cuando alguien pida IProductoService, .NET entregará un ProductoService.
// Cuando alguien pida IProductoRepository, .NET entregará un ProductoRepositoryInMemory.
// ---------------------------------------------------------------
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IProductoRepository, ProductoRepositoryInMemory>();

// ---------------------------------------------------------------
// Swagger: genera la interfaz visual para probar los endpoints
// ---------------------------------------------------------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Habilitamos Swagger solo en entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Le decimos a .NET que use los controladores que registramos
app.MapControllers();

app.Run();