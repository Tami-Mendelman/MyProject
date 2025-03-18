using Common.Dto;
using Mock;
//using Repository.Entities;
using Repository.Interfaces;
using Repository.Repositor;
//using Repository.Repositories;
using Respository.Entities;
using Service.Interfaces;
//using Service.Services;
using Service.Servicess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//הגדרת התלויות
builder.Services.AddScoped<IService<UserDto>, UserService>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddAutoMapper(typeof(MyMapper));
builder.Services.AddDbContext<IContext, Database>();


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
