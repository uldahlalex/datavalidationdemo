using api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<PetDatabase>();
builder.Services.AddScoped<PetService>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
