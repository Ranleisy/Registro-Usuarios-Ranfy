using Microsoft.EntityFrameworkCore;
using DenunciaUnaBestia.Domain.Entities;
using DenunciaUnaBestia.Domain.Repository.Infrastructure.Dependencies.Context;
using DenunciaUnaBestia.Domain.Repository.Infrastructure.Core;
using DenunciaUnaBestia.Domain.Repository.Infrastructure.Interfaces;

namespace DenunciaUnaBestia.Domain.Repository.Infrastructure.Repositories;

public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(DenunciaUnaBestiaContext context) : base(context) { }

    public async Task<Usuario?> GetByEmailAsync(string email)
        => await _dbSet.FirstOrDefaultAsync(u => u.Email == email && u.IsActive);

    public async Task<IEnumerable<Usuario>> GetSeguidoresAsync(int usuarioId)
        => await _dbSet.Where(u => u.Seguidos.Any(s => s.SeguidoId == usuarioId) && u.IsActive).ToListAsync();
}

public class PostRepository : BaseRepository<Post>, IPostRepository
{
    public PostRepository(DenunciaUnaBestiaContext context) : base(context) { }

    public async Task<IEnumerable<Post>> GetByUsuarioIdAsync(int usuarioId)
        => await _dbSet.Where(p => p.UsuarioId == usuarioId && p.IsActive)
            .Include(p => p.Comentarios).Include(p => p.Likes)
            .OrderByDescending(p => p.CreatedAt).ToListAsync();

    public async Task<IEnumerable<Post>> GetFeedAsync(int usuarioId)
        => await _dbSet.Where(p => p.IsActive &&
                (p.UsuarioId == usuarioId || p.Usuario.Seguidores.Any(s => s.SeguidorId == usuarioId)))
            .Include(p => p.Usuario).Include(p => p.Likes).Include(p => p.Comentarios)
            .OrderByDescending(p => p.CreatedAt).ToListAsync();
}

public class ComentarioRepository : BaseRepository<Comentario>, IComentarioRepository
{
    public ComentarioRepository(DenunciaUnaBestiaContext context) : base(context) { }

    public async Task<IEnumerable<Comentario>> GetByPostIdAsync(int postId)
        => await _dbSet.Where(c => c.PostId == postId && c.IsActive)
            .Include(c => c.Usuario).OrderByDescending(c => c.CreatedAt).ToListAsync();
}

public class LikeRepository : BaseRepository<Like>, ILikeRepository
{
    public LikeRepository(DenunciaUnaBestiaContext context) : base(context) { }

    public async Task<IEnumerable<Like>> GetByPostIdAsync(int postId)
        => await _dbSet.Where(l => l.PostId == postId && l.IsActive).ToListAsync();

    public async Task<bool> ExistsAsync(int usuarioId, int postId)
        => await _dbSet.AnyAsync(l => l.UsuarioId == usuarioId && l.PostId == postId && l.IsActive);
}

public class SeguidorRepository : BaseRepository<Seguidor>, ISeguidorRepository
{
    public SeguidorRepository(DenunciaUnaBestiaContext context) : base(context) { }

    public async Task<bool> IsFollowingAsync(int seguidorId, int seguidoId)
        => await _dbSet.AnyAsync(s => s.SeguidorId == seguidorId && s.SeguidoId == seguidoId && s.IsActive);

    public async Task<IEnumerable<Seguidor>> GetSeguidosAsync(int usuarioId)
        => await _dbSet.Where(s => s.SeguidorId == usuarioId && s.IsActive)
            .Include(s => s.UsuarioSeguido).ToListAsync();
}
