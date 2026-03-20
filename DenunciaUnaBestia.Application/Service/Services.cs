using DenunciaUnaBestia.Application.Contract;
using DenunciaUnaBestia.Application.Core;
using DenunciaUnaBestia.Application.Dtos.Usuario;
using DenunciaUnaBestia.Application.Dtos.Post;
using DenunciaUnaBestia.Application.Dtos.Comentario;
using DenunciaUnaBestia.Application.Dtos.Like;
using DenunciaUnaBestia.Application.Dtos.Seguidor;
using DenunciaUnaBestia.Domain.Entities;
using DenunciaUnaBestia.Domain.Repository.Infrastructure.Interfaces;

namespace DenunciaUnaBestia.Application.Service;

// ─── UsuarioService ──────────────────────────────────────────────────────────
public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repo;
    public UsuarioService(IUsuarioRepository repo) => _repo = repo;

    public async Task<ServiceResult<IEnumerable<UsuarioDto>>> GetAllAsync()
    {
        var items = await _repo.GetAllAsync();
        var dtos = items.Select(u => new UsuarioDto
        {
            Id = u.Id, NombreUsuario = u.NombreUsuario,
            Email = u.Email, FotoPerfil = u.FotoPerfil,
            Bio = u.Bio, CreatedAt = u.CreatedAt
        });
        return ServiceResult<IEnumerable<UsuarioDto>>.Ok(dtos);
    }

    public async Task<ServiceResult<UsuarioDto>> GetByIdAsync(int id)
    {
        var u = await _repo.GetByIdAsync(id);
        if (u == null) return ServiceResult<UsuarioDto>.Fail("Usuario no encontrado.");
        return ServiceResult<UsuarioDto>.Ok(new UsuarioDto
        {
            Id = u.Id, NombreUsuario = u.NombreUsuario,
            Email = u.Email, FotoPerfil = u.FotoPerfil,
            Bio = u.Bio, CreatedAt = u.CreatedAt
        });
    }

    public async Task<ServiceResult<UsuarioDto>> GetByEmailAsync(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return ServiceResult<UsuarioDto>.Fail("El email es requerido.");
        var u = await _repo.GetByEmailAsync(email);
        if (u == null) return ServiceResult<UsuarioDto>.Fail("Usuario no encontrado.");
        return ServiceResult<UsuarioDto>.Ok(new UsuarioDto
        {
            Id = u.Id, NombreUsuario = u.NombreUsuario,
            Email = u.Email, FotoPerfil = u.FotoPerfil,
            Bio = u.Bio, CreatedAt = u.CreatedAt
        });
    }

    public async Task<ServiceResult<IEnumerable<UsuarioDto>>> GetSeguidoresAsync(int usuarioId)
    {
        var items = await _repo.GetSeguidoresAsync(usuarioId);
        var dtos = items.Select(u => new UsuarioDto
        {
            Id = u.Id, NombreUsuario = u.NombreUsuario, Email = u.Email
        });
        return ServiceResult<IEnumerable<UsuarioDto>>.Ok(dtos);
    }

    public async Task<ServiceResult> CreateAsync(CreateUsuarioDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.NombreUsuario))
            return ServiceResult.Fail("El nombre de usuario es requerido.");
        if (string.IsNullOrWhiteSpace(dto.Email))
            return ServiceResult.Fail("El email es requerido.");
        if (!dto.Email.Contains("@"))
            return ServiceResult.Fail("El email no es válido.");
        if (string.IsNullOrWhiteSpace(dto.Password) || dto.Password.Length < 6)
            return ServiceResult.Fail("La contraseña debe tener al menos 6 caracteres.");

        await _repo.AddAsync(new Usuario
        {
            NombreUsuario = dto.NombreUsuario,
            Email = dto.Email,
            PasswordHash = dto.Password,
            FotoPerfil = dto.FotoPerfil,
            Bio = dto.Bio
        });
        return ServiceResult.Ok("Usuario creado exitosamente.");
    }

    public async Task<ServiceResult> UpdateAsync(int id, CreateUsuarioDto dto)
    {
        var u = await _repo.GetByIdAsync(id);
        if (u == null) return ServiceResult.Fail("Usuario no encontrado.");
        if (string.IsNullOrWhiteSpace(dto.NombreUsuario))
            return ServiceResult.Fail("El nombre de usuario es requerido.");
        if (string.IsNullOrWhiteSpace(dto.Email))
            return ServiceResult.Fail("El email es requerido.");
        if (!dto.Email.Contains("@"))
            return ServiceResult.Fail("El email no es válido.");

        u.NombreUsuario = dto.NombreUsuario;
        u.Email = dto.Email;
        u.FotoPerfil = dto.FotoPerfil;
        u.Bio = dto.Bio;
        await _repo.UpdateAsync(u);
        return ServiceResult.Ok("Usuario actualizado exitosamente.");
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var u = await _repo.GetByIdAsync(id);
        if (u == null) return ServiceResult.Fail("Usuario no encontrado.");
        await _repo.DeleteAsync(id);
        return ServiceResult.Ok("Usuario eliminado exitosamente.");
    }
}

// ─── PostService ─────────────────────────────────────────────────────────────
public class PostService : IPostService
{
    private readonly IPostRepository _repo;
    public PostService(IPostRepository repo) => _repo = repo;

    private static PostDto ToDto(Post p) => new()
    {
        Id = p.Id, Contenido = p.Contenido, ImagenUrl = p.ImagenUrl,
        UsuarioId = p.UsuarioId, NombreUsuario = p.Usuario?.NombreUsuario ?? "",
        CreatedAt = p.CreatedAt
    };

    public async Task<ServiceResult<IEnumerable<PostDto>>> GetAllAsync() =>
        ServiceResult<IEnumerable<PostDto>>.Ok((await _repo.GetAllAsync()).Select(ToDto));

    public async Task<ServiceResult<PostDto>> GetByIdAsync(int id)
    {
        var p = await _repo.GetByIdAsync(id);
        return p == null ? ServiceResult<PostDto>.Fail("Post no encontrado.") : ServiceResult<PostDto>.Ok(ToDto(p));
    }

    public async Task<ServiceResult<IEnumerable<PostDto>>> GetByUsuarioIdAsync(int usuarioId) =>
        ServiceResult<IEnumerable<PostDto>>.Ok((await _repo.GetByUsuarioIdAsync(usuarioId)).Select(ToDto));

    public async Task<ServiceResult<IEnumerable<PostDto>>> GetFeedAsync(int usuarioId) =>
        ServiceResult<IEnumerable<PostDto>>.Ok((await _repo.GetFeedAsync(usuarioId)).Select(ToDto));

    public async Task<ServiceResult> CreateAsync(CreatePostDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Contenido))
            return ServiceResult.Fail("El contenido es requerido.");
        if (dto.Contenido.Length > 500)
            return ServiceResult.Fail("El contenido no puede superar 500 caracteres.");
        if (dto.UsuarioId <= 0)
            return ServiceResult.Fail("El usuario es requerido.");

        await _repo.AddAsync(new Post
        {
            Contenido = dto.Contenido, ImagenUrl = dto.ImagenUrl, UsuarioId = dto.UsuarioId
        });
        return ServiceResult.Ok("Post creado exitosamente.");
    }

    public async Task<ServiceResult> UpdateAsync(int id, CreatePostDto dto)
    {
        var p = await _repo.GetByIdAsync(id);
        if (p == null) return ServiceResult.Fail("Post no encontrado.");
        if (string.IsNullOrWhiteSpace(dto.Contenido))
            return ServiceResult.Fail("El contenido es requerido.");
        if (dto.Contenido.Length > 500)
            return ServiceResult.Fail("El contenido no puede superar 500 caracteres.");

        p.Contenido = dto.Contenido;
        p.ImagenUrl = dto.ImagenUrl;
        await _repo.UpdateAsync(p);
        return ServiceResult.Ok("Post actualizado exitosamente.");
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var p = await _repo.GetByIdAsync(id);
        if (p == null) return ServiceResult.Fail("Post no encontrado.");
        await _repo.DeleteAsync(id);
        return ServiceResult.Ok("Post eliminado exitosamente.");
    }
}

// ─── ComentarioService ───────────────────────────────────────────────────────
public class ComentarioService : IComentarioService
{
    private readonly IComentarioRepository _repo;
    public ComentarioService(IComentarioRepository repo) => _repo = repo;

    private static ComentarioDto ToDto(Comentario c) => new()
    {
        Id = c.Id, Contenido = c.Contenido, UsuarioId = c.UsuarioId,
        NombreUsuario = c.Usuario?.NombreUsuario ?? "", PostId = c.PostId, CreatedAt = c.CreatedAt
    };

    public async Task<ServiceResult<IEnumerable<ComentarioDto>>> GetAllAsync() =>
        ServiceResult<IEnumerable<ComentarioDto>>.Ok((await _repo.GetAllAsync()).Select(ToDto));

    public async Task<ServiceResult<ComentarioDto>> GetByIdAsync(int id)
    {
        var c = await _repo.GetByIdAsync(id);
        return c == null ? ServiceResult<ComentarioDto>.Fail("Comentario no encontrado.") : ServiceResult<ComentarioDto>.Ok(ToDto(c));
    }

    public async Task<ServiceResult<IEnumerable<ComentarioDto>>> GetByPostIdAsync(int postId) =>
        ServiceResult<IEnumerable<ComentarioDto>>.Ok((await _repo.GetByPostIdAsync(postId)).Select(ToDto));

    public async Task<ServiceResult> CreateAsync(CreateComentarioDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Contenido))
            return ServiceResult.Fail("El contenido es requerido.");
        if (dto.Contenido.Length > 300)
            return ServiceResult.Fail("El comentario no puede superar 300 caracteres.");
        if (dto.UsuarioId <= 0)
            return ServiceResult.Fail("El usuario es requerido.");
        if (dto.PostId <= 0)
            return ServiceResult.Fail("El post es requerido.");

        await _repo.AddAsync(new Comentario
        {
            Contenido = dto.Contenido, UsuarioId = dto.UsuarioId, PostId = dto.PostId
        });
        return ServiceResult.Ok("Comentario creado exitosamente.");
    }

    public async Task<ServiceResult> UpdateAsync(int id, CreateComentarioDto dto)
    {
        var c = await _repo.GetByIdAsync(id);
        if (c == null) return ServiceResult.Fail("Comentario no encontrado.");
        if (string.IsNullOrWhiteSpace(dto.Contenido))
            return ServiceResult.Fail("El contenido es requerido.");

        c.Contenido = dto.Contenido;
        await _repo.UpdateAsync(c);
        return ServiceResult.Ok("Comentario actualizado exitosamente.");
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var c = await _repo.GetByIdAsync(id);
        if (c == null) return ServiceResult.Fail("Comentario no encontrado.");
        await _repo.DeleteAsync(id);
        return ServiceResult.Ok("Comentario eliminado exitosamente.");
    }
}

// ─── LikeService ─────────────────────────────────────────────────────────────
public class LikeService : ILikeService
{
    private readonly ILikeRepository _repo;
    public LikeService(ILikeRepository repo) => _repo = repo;

    private static LikeDto ToDto(Like l) => new()
    {
        Id = l.Id, UsuarioId = l.UsuarioId,
        NombreUsuario = l.Usuario?.NombreUsuario ?? "",
        PostId = l.PostId, CreatedAt = l.CreatedAt
    };

    public async Task<ServiceResult<IEnumerable<LikeDto>>> GetAllAsync() =>
        ServiceResult<IEnumerable<LikeDto>>.Ok((await _repo.GetAllAsync()).Select(ToDto));

    public async Task<ServiceResult<LikeDto>> GetByIdAsync(int id)
    {
        var l = await _repo.GetByIdAsync(id);
        return l == null ? ServiceResult<LikeDto>.Fail("Like no encontrado.") : ServiceResult<LikeDto>.Ok(ToDto(l));
    }

    public async Task<ServiceResult<IEnumerable<LikeDto>>> GetByPostIdAsync(int postId) =>
        ServiceResult<IEnumerable<LikeDto>>.Ok((await _repo.GetByPostIdAsync(postId)).Select(ToDto));

    public async Task<ServiceResult<bool>> ExistsAsync(int usuarioId, int postId) =>
        ServiceResult<bool>.Ok(await _repo.ExistsAsync(usuarioId, postId));

    public async Task<ServiceResult> CreateAsync(CreateLikeDto dto)
    {
        if (dto.UsuarioId <= 0) return ServiceResult.Fail("El usuario es requerido.");
        if (dto.PostId <= 0) return ServiceResult.Fail("El post es requerido.");
        if (await _repo.ExistsAsync(dto.UsuarioId, dto.PostId))
            return ServiceResult.Fail("Ya diste like a este post.");

        await _repo.AddAsync(new Like { UsuarioId = dto.UsuarioId, PostId = dto.PostId });
        return ServiceResult.Ok("Like agregado exitosamente.");
    }

    public async Task<ServiceResult> UpdateAsync(int id, CreateLikeDto dto) =>
        ServiceResult.Fail("Los likes no se pueden actualizar.");

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var l = await _repo.GetByIdAsync(id);
        if (l == null) return ServiceResult.Fail("Like no encontrado.");
        await _repo.DeleteAsync(id);
        return ServiceResult.Ok("Like eliminado exitosamente.");
    }
}

// ─── SeguidorService ─────────────────────────────────────────────────────────
public class SeguidorService : ISeguidorService
{
    private readonly ISeguidorRepository _repo;
    public SeguidorService(ISeguidorRepository repo) => _repo = repo;

    private static SeguidorDto ToDto(Domain.Entities.Seguidor s) => new()
    {
        Id = s.Id, SeguidorId = s.SeguidorId,
        NombreUsuarioSeguidor = s.UsuarioSeguidor?.NombreUsuario ?? "",
        SeguidoId = s.SeguidoId,
        NombreUsuarioSeguido = s.UsuarioSeguido?.NombreUsuario ?? "",
        CreatedAt = s.CreatedAt
    };

    public async Task<ServiceResult<IEnumerable<SeguidorDto>>> GetAllAsync() =>
        ServiceResult<IEnumerable<SeguidorDto>>.Ok((await _repo.GetAllAsync()).Select(ToDto));

    public async Task<ServiceResult<SeguidorDto>> GetByIdAsync(int id)
    {
        var s = await _repo.GetByIdAsync(id);
        return s == null ? ServiceResult<SeguidorDto>.Fail("Seguidor no encontrado.") : ServiceResult<SeguidorDto>.Ok(ToDto(s));
    }

    public async Task<ServiceResult<bool>> IsFollowingAsync(int seguidorId, int seguidoId) =>
        ServiceResult<bool>.Ok(await _repo.IsFollowingAsync(seguidorId, seguidoId));

    public async Task<ServiceResult<IEnumerable<SeguidorDto>>> GetSeguidosAsync(int usuarioId) =>
        ServiceResult<IEnumerable<SeguidorDto>>.Ok((await _repo.GetSeguidosAsync(usuarioId)).Select(ToDto));

    public async Task<ServiceResult> CreateAsync(CreateSeguidorDto dto)
    {
        if (dto.SeguidorId <= 0) return ServiceResult.Fail("El seguidor es requerido.");
        if (dto.SeguidoId <= 0) return ServiceResult.Fail("El seguido es requerido.");
        if (dto.SeguidorId == dto.SeguidoId) return ServiceResult.Fail("No puedes seguirte a ti mismo.");
        if (await _repo.IsFollowingAsync(dto.SeguidorId, dto.SeguidoId))
            return ServiceResult.Fail("Ya sigues a este usuario.");

        await _repo.AddAsync(new Domain.Entities.Seguidor
        {
            SeguidorId = dto.SeguidorId, SeguidoId = dto.SeguidoId
        });
        return ServiceResult.Ok("Ahora sigues a este usuario.");
    }

    public async Task<ServiceResult> UpdateAsync(int id, CreateSeguidorDto dto) =>
        ServiceResult.Fail("Las relaciones de seguimiento no se pueden actualizar.");

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var s = await _repo.GetByIdAsync(id);
        if (s == null) return ServiceResult.Fail("Seguidor no encontrado.");
        await _repo.DeleteAsync(id);
        return ServiceResult.Ok("Dejaste de seguir a este usuario.");
    }
}
