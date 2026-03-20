namespace RedSocial.Infrastructure.Models;

public class UsuarioModel
{
    public int Id { get; set; }
    public string NombreUsuario { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? FotoPerfil { get; set; }
    public string? Bio { get; set; }
}

public class PostModel
{
    public int Id { get; set; }
    public string Contenido { get; set; } = string.Empty;
    public string? ImagenUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public string NombreUsuario { get; set; } = string.Empty;
    public int TotalLikes { get; set; }
    public int TotalComentarios { get; set; }
}

public class ComentarioModel
{
    public int Id { get; set; }
    public string Contenido { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public string NombreUsuario { get; set; } = string.Empty;
}

public class LikeModel
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public int PostId { get; set; }
}

public class SeguidorModel
{
    public int Id { get; set; }
    public int SeguidorId { get; set; }
    public int SeguidoId { get; set; }
    public string NombreUsuarioSeguidor { get; set; } = string.Empty;
    public string NombreUsuarioSeguido { get; set; } = string.Empty;
}
