using Microsoft.EntityFrameworkCore;
using UniversityACS.API.Extensions;
using UniversityACS.API.Middleware;
using UniversityACS.Data.DataContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("Default"),
    x => x.MigrationsAssembly("UniversityACS.API")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAnyOrigin");
app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<AppExceptionsMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

