using JogoDaForca.Data;
using JogoDaForca.Repositories.Forca;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
});
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddTransient<IForcaRepository, ForcaRepository>();

var app = builder.Build();
app.MapControllers();

app.Run();
