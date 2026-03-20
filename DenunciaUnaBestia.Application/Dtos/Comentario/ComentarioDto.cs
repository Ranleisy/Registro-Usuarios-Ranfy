namespace DenunciaUnaBestia.Application.Dtos.Comentario;

public class ComentarioDto
{
    public int Id { get; set; }
    public string Contenido { get; set; } = string.Empty;
    public int UsuarioId { get; set; }
    public string NombreUsuario { get; set; } = string.Empty;
    public int PostId { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class CreateComentarioDto
{
    public string Contenido { get; set; } = string.Empty;
    public int UsuarioId { get; set; }
    public int PostId { get; set; }
}
