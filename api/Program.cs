using api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<PetDatabase>();
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddControllers();


builder.Services.AddOpenApiDocument();


var app = builder.Build();
app.UseOpenApi();
app.UseSwaggerUi();
app.MapControllers();

app.Run();
