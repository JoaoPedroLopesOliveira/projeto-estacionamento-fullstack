using ApiEstacionamento;
using ApiEstacionamento.DbContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<EstacionamentoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EstacionamentoDatabase")));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();