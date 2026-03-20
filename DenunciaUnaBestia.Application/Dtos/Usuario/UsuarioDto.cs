namespace DenunciaUnaBestia.Application.Dtos.Usuario;

public class UsuarioDto
{
    public int Id { get; set; }
    public string NombreUsuario { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? FotoPerfil { get; set; }
    public string? Bio { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class CreateUsuarioDto
{
    public string NombreUsuario { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? FotoPerfil { get; set; }
    public string? Bio { get; set; }
}
