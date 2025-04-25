var builder = WebApplication.CreateBuilder(args);

// 1) Registramos el servicio de ML.NET
builder.Services.AddSingleton<SentimentService>();

// 2) Añadir soporte para controladores
builder.Services.AddControllers();

// 3) Swagger (opcional, pero útil para probar)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Solo en Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Mapear los controladores
app.MapControllers();

app.Run();