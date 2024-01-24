using Logistecsa.Domain.DataManagers;
using Logistecsa.Domain.Entities;
using Logistecsa.Domain.Interfaces;
using Logistecsa.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//EF DbContext
builder.Services.AddDbContext<LogistecsaDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IRepository<Client>, ClientManager>();
builder.Services.AddScoped<IRepository<Comment>, CommentManager>();
builder.Services.AddScoped<IRepository<Project>, ProjectManager>();
builder.Services.AddScoped<IRepository<Tarea>, TareaManager>();
builder.Services.AddScoped<IRepository<User>, UserManager>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
