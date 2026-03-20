namespace DenunciaUnaBestia.Domain.Entities;

public class Usuario
{
    public int Id { get; set; }
    public string NombreUsuario { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string? FotoPerfil { get; set; }
    public string? Bio { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<Post> Posts { get; set; } = new List<Post>();
    public ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
    public ICollection<Like> Likes { get; set; } = new List<Like>();
    public ICollection<Seguidor> Seguidores { get; set; } = new List<Seguidor>();
    public ICollection<Seguidor> Seguidos { get; set; } = new List<Seguidor>();
}

public class Post
{
    public int Id { get; set; }
    public string Contenido { get; set; } = string.Empty;
    public string? ImagenUrl { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; } = true;

    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; } = null!;
    public ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
    public ICollection<Like> Likes { get; set; } = new List<Like>();
}

public class Comentario
{
    public int Id { get; set; }
    public string Contenido { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; } = true;

    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; } = null!;
    public int PostId { get; set; }
    public Post Post { get; set; } = null!;
}

public class Like
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; } = true;

    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; } = null!;
    public int PostId { get; set; }
    public Post Post { get; set; } = null!;
}

public class Seguidor
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; } = true;

    public int SeguidorId { get; set; }
    public Usuario UsuarioSeguidor { get; set; } = null!;
    public int SeguidoId { get; set; }
    public Usuario UsuarioSeguido { get; set; } = null!;
}
