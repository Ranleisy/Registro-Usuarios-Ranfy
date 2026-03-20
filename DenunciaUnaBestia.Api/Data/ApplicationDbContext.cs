using Microsoft.EntityFrameworkCore;
using DenunciaUnaBestia.Api.Models.Entities;

namespace DenunciaUnaBestia.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
}