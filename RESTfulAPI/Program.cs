using Microsoft.EntityFrameworkCore;
using RESTfulAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TutorialDbContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("Default"), new MySqlServerVersion(new Version(10, 4, 32)));
});
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
