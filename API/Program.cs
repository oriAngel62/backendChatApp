using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PomeloDB>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("PomeloDB") ?? throw new InvalidOperationException("Connection string 'PomeloDB' not found."), MariaDbServerVersion.AutoDetect(builder.Configuration.GetConnectionString("PomeloDB"))));


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
