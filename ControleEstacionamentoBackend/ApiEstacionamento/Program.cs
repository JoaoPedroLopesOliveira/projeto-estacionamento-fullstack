using ApiEstacionamento;
using ApiEstacionamento.DbContext;
using ApiEstacionamento.Interfaces;
using ApiEstacionamento.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IVeiculoService, VeiculosService>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EstacionamentoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EstacionamentoDatabase")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();