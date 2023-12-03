using JogoDaForca.Data;
using JogoDaForca.Repositories.Forca;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddTransient<IForcaRepository, ForcaRepository>();

var app = builder.Build();
app.MapControllers();

app.Run();
