using DenunciaUnaBestia.Domain.Entities;

namespace DenunciaUnaBestia.Domain.Repository.Infrastructure.Interfaces;

public interface IUsuarioRepository : IBaseRepository<Usuario>
{
    Task<Usuario?> GetByEmailAsync(string email);
    Task<IEnumerable<Usuario>> GetSeguidoresAsync(int usuarioId);
}

public interface IPostRepository : IBaseRepository<Post>
{
    Task<IEnumerable<Post>> GetByUsuarioIdAsync(int usuarioId);
    Task<IEnumerable<Post>> GetFeedAsync(int usuarioId);
}

public interface IComentarioRepository : IBaseRepository<Comentario>
{
    Task<IEnumerable<Comentario>> GetByPostIdAsync(int postId);
}

public interface ILikeRepository : IBaseRepository<Like>
{
    Task<IEnumerable<Like>> GetByPostIdAsync(int postId);
    Task<bool> ExistsAsync(int usuarioId, int postId);
}

public interface ISeguidorRepository : IBaseRepository<Seguidor>
{
    Task<bool> IsFollowingAsync(int seguidorId, int seguidoId);
    Task<IEnumerable<Seguidor>> GetSeguidosAsync(int usuarioId);
}
