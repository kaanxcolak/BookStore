using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApi.DBOperations;
using WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseInMemoryDatabase(databaseName: "BookStoreDB"));

//AutoMapper ayar?
//builder.Services.AddAutoMapper(x =>
//{
//    x.AddExpressionMapping();
//    x.AddProfile(typeof(Maps));
//});
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Initialize data.
using var scope = app.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;
DataGenerator.Initialize(serviceProvider);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCustomExceptionMiddle();

app.MapControllers();

app.Run();
