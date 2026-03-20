using DenunciaUnaBestia.Domain.Core.Entities;

namespace DenunciaUnaBestia.Domain.Entities;

public class User : Base
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;

  
    // public string PasswordHash { get; set; } = string.Empty;
    // public string ProfilePictureUrl { get; set; } = string.Empty;
    // public DateTime? LastLogin { get; set; }
}
