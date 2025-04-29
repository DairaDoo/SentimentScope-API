using Microsoft.AspNetCore.Cors;

var builder = WebApplication.CreateBuilder(args);

// 1) Registrar el servicio de ML.NET
builder.Services.AddSingleton<SentimentService>();

// 2) Añadir soporte para controladores
builder.Services.AddControllers();

// 3) Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 4) Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

// 5) Asignar puerto dinámico para Render
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

var app = builder.Build();

// ✅ Swagger disponible en todos los entornos (no solo Development)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SentimentScope API V1");
    c.RoutePrefix = "swagger"; // Ruta donde se muestra Swagger
});

// ⚠️ Opcional: desactivar HTTPS redirection en producción para evitar errores
if (!app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

app.UseCors("AllowAllOrigins");
app.UseAuthorization();
app.MapControllers();

app.Run();
