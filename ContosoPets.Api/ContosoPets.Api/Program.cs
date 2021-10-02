using ContosoPets.DataAccess.Data;
using ContosoPets.DataAccess.Services;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ContosoPetsContext");
builder.Services.AddScoped<OrderService>();
builder.Services.AddDbContext<ContosoPetsContext>(options => options.UseSqlite(connectionString).EnableSensitiveDataLogging(builder.Configuration.GetValue<bool>("Logging:EnableSqlParameterLogging")));
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "ContosoPets.Api", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ContosoPets.Api v1"));
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
