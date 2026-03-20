using DenunciaUnaBestia.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DenunciaUnaBestia.Domain.Repository.Infrastructure.Dependencies.Context;

public class DenunciaUnaBestiaContext : DbContext
{
    public DenunciaUnaBestiaContext(DbContextOptions<DenunciaUnaBestiaContext> options)
        : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comentario> Comentarios { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Seguidor> Seguidores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>(e =>
        {
            e.HasKey(u => u.Id);
            e.Property(u => u.NombreUsuario).IsRequired().HasMaxLength(50);
            e.Property(u => u.Email).IsRequired().HasMaxLength(100);
            e.HasIndex(u => u.Email).IsUnique();
            e.HasIndex(u => u.NombreUsuario).IsUnique();
        });

        modelBuilder.Entity<Post>(e =>
        {
            e.HasKey(p => p.Id);
            e.Property(p => p.Contenido).IsRequired().HasMaxLength(500);
            e.HasOne(p => p.Usuario)
             .WithMany(u => u.Posts)
             .HasForeignKey(p => p.UsuarioId)
             .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Comentario>(e =>
        {
            e.HasKey(c => c.Id);
            e.Property(c => c.Contenido).IsRequired().HasMaxLength(300);
            e.HasOne(c => c.Usuario)
             .WithMany(u => u.Comentarios)
             .HasForeignKey(c => c.UsuarioId)
             .OnDelete(DeleteBehavior.NoAction);
            e.HasOne(c => c.Post)
             .WithMany(p => p.Comentarios)
             .HasForeignKey(c => c.PostId)
             .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Like>(e =>
        {
            e.HasKey(l => l.Id);
            e.HasOne(l => l.Usuario)
             .WithMany(u => u.Likes)
             .HasForeignKey(l => l.UsuarioId)
             .OnDelete(DeleteBehavior.NoAction);
            e.HasOne(l => l.Post)
             .WithMany(p => p.Likes)
             .HasForeignKey(l => l.PostId)
             .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Seguidor>(e =>
        {
            e.HasKey(s => s.Id);
            e.HasOne(s => s.UsuarioSeguidor)
             .WithMany(u => u.Seguidores)
             .HasForeignKey(s => s.SeguidorId)
             .OnDelete(DeleteBehavior.NoAction);
            e.HasOne(s => s.UsuarioSeguido)
             .WithMany(u => u.Seguidos)
             .HasForeignKey(s => s.SeguidoId)
             .OnDelete(DeleteBehavior.NoAction);
        });
    }
}
