namespace DenunciaUnaBestia.Application.Dtos.Like;

public class LikeDto
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public string NombreUsuario { get; set; } = string.Empty;
    public int PostId { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class CreateLikeDto
{
    public int UsuarioId { get; set; }
    public int PostId { get; set; }
}
