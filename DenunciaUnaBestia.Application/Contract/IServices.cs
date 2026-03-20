using DenunciaUnaBestia.Application.Core;
using DenunciaUnaBestia.Application.Dtos.Usuario;
using DenunciaUnaBestia.Application.Dtos.Post;
using DenunciaUnaBestia.Application.Dtos.Comentario;
using DenunciaUnaBestia.Application.Dtos.Like;
using DenunciaUnaBestia.Application.Dtos.Seguidor;

namespace DenunciaUnaBestia.Application.Contract;

public interface IUsuarioService : IBaseService<UsuarioDto, CreateUsuarioDto>
{
    Task<ServiceResult<UsuarioDto>> GetByEmailAsync(string email);
    Task<ServiceResult<IEnumerable<UsuarioDto>>> GetSeguidoresAsync(int usuarioId);
}

public interface IPostService : IBaseService<PostDto, CreatePostDto>
{
    Task<ServiceResult<IEnumerable<PostDto>>> GetByUsuarioIdAsync(int usuarioId);
    Task<ServiceResult<IEnumerable<PostDto>>> GetFeedAsync(int usuarioId);
}

public interface IComentarioService : IBaseService<ComentarioDto, CreateComentarioDto>
{
    Task<ServiceResult<IEnumerable<ComentarioDto>>> GetByPostIdAsync(int postId);
}

public interface ILikeService : IBaseService<LikeDto, CreateLikeDto>
{
    Task<ServiceResult<IEnumerable<LikeDto>>> GetByPostIdAsync(int postId);
    Task<ServiceResult<bool>> ExistsAsync(int usuarioId, int postId);
}

public interface ISeguidorService : IBaseService<SeguidorDto, CreateSeguidorDto>
{
    Task<ServiceResult<bool>> IsFollowingAsync(int seguidorId, int seguidoId);
    Task<ServiceResult<IEnumerable<SeguidorDto>>> GetSeguidosAsync(int usuarioId);
}
