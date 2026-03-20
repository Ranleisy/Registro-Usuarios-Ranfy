using Microsoft.EntityFrameworkCore;
using DenunciaUnaBestia.Domain.Repository.Infrastructure.Dependencies.Context;
using DenunciaUnaBestia.Domain.Repository.Infrastructure.Interfaces;
using DenunciaUnaBestia.Domain.Repository.Infrastructure.Repositories;
using DenunciaUnaBestia.Application.Contract;
using DenunciaUnaBestia.Application.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DenunciaUnaBestiaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositorios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IComentarioRepository, ComentarioRepository>();
builder.Services.AddScoped<ILikeRepository, LikeRepository>();
builder.Services.AddScoped<ISeguidorRepository, SeguidorRepository>();

// Servicios
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IComentarioService, ComentarioService>();
builder.Services.AddScoped<ILikeService, LikeService>();
builder.Services.AddScoped<ISeguidorService, SeguidorService>();

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