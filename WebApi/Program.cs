using Microsoft.EntityFrameworkCore;
using WebApi.Data;

var builder = WebApplication.CreateBuilder(args);

var DbConnectionString = builder.Configuration.GetConnectionString("DbConnectionString");

builder.Services.AddDbContext<AppDbcontext>(options =>
    options.UseNpgsql(DbConnectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        c => {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger v1");
        c.RoutePrefix = String.Empty;
        }   
    );
    
}
app.UseHttpsRedirection();


app.MapControllers();


app.Run();
