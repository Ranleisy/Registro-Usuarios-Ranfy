namespace DenunciaUnaBestia.Application.Dtos.Post;

public class PostDto
{
    public int Id { get; set; }
    public string Contenido { get; set; } = string.Empty;
    public string? ImagenUrl { get; set; }
    public int UsuarioId { get; set; }
    public string NombreUsuario { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}

public class CreatePostDto
{
    public string Contenido { get; set; } = string.Empty;
    public string? ImagenUrl { get; set; }
    public int UsuarioId { get; set; }
}
