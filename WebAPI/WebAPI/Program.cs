var builder = WebApplication.CreateBuilder(args);

// 1. Dodaj us³ugê CORS z odpowiednimi zasadami
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:64131") 
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Dodaj inne us³ugi
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 2. U¿yj CORS przed mapowaniem kontrolerów
app.UseCors("AllowAngularApp");

// Konfiguracja œrodowiska i pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();