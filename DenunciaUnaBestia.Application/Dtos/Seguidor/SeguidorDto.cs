namespace DenunciaUnaBestia.Application.Dtos.Seguidor;

public class SeguidorDto
{
    public int Id { get; set; }
    public int SeguidorId { get; set; }
    public string NombreUsuarioSeguidor { get; set; } = string.Empty;
    public int SeguidoId { get; set; }
    public string NombreUsuarioSeguido { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}

public class CreateSeguidorDto
{
    public int SeguidorId { get; set; }
    public int SeguidoId { get; set; }
}
