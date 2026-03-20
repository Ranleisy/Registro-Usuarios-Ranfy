using Microsoft.AspNetCore.Mvc;
using DenunciaUnaBestia.Domain.Entities;
using DenunciaUnaBestia.Domain.Repository.Infrastructure.Interfaces;

namespace DenunciaUnaBestia.Api.Controllers;

// ─── Usuario ────────────────────────────────────────────────────────────────
[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioRepository _repo;
    public UsuariosController(IUsuarioRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _repo.GetByIdAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpGet("{id}/seguidores")]
    public async Task<IActionResult> GetSeguidores(int id) =>
        Ok(await _repo.GetSeguidoresAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create(Usuario entity)
    {
        await _repo.AddAsync(entity);
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Usuario entity)
    {
        if (id != entity.Id) return BadRequest();
        await _repo.UpdateAsync(entity);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repo.DeleteAsync(id);
        return NoContent();
    }
}

// ─── Post ────────────────────────────────────────────────────────────────────
[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostRepository _repo;
    public PostsController(IPostRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _repo.GetByIdAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpGet("usuario/{usuarioId}")]
    public async Task<IActionResult> GetByUsuario(int usuarioId) =>
        Ok(await _repo.GetByUsuarioIdAsync(usuarioId));

    [HttpGet("feed/{usuarioId}")]
    public async Task<IActionResult> GetFeed(int usuarioId) =>
        Ok(await _repo.GetFeedAsync(usuarioId));

    [HttpPost]
    public async Task<IActionResult> Create(Post entity)
    {
        await _repo.AddAsync(entity);
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Post entity)
    {
        if (id != entity.Id) return BadRequest();
        await _repo.UpdateAsync(entity);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repo.DeleteAsync(id);
        return NoContent();
    }
}

// ─── Comentario ──────────────────────────────────────────────────────────────
[ApiController]
[Route("api/[controller]")]
public class ComentariosController : ControllerBase
{
    private readonly IComentarioRepository _repo;
    public ComentariosController(IComentarioRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _repo.GetByIdAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpGet("post/{postId}")]
    public async Task<IActionResult> GetByPost(int postId) =>
        Ok(await _repo.GetByPostIdAsync(postId));

    [HttpPost]
    public async Task<IActionResult> Create(Comentario entity)
    {
        await _repo.AddAsync(entity);
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Comentario entity)
    {
        if (id != entity.Id) return BadRequest();
        await _repo.UpdateAsync(entity);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repo.DeleteAsync(id);
        return NoContent();
    }
}

// ─── Like ─────────────────────────────────────────────────────────────────────
[ApiController]
[Route("api/[controller]")]
public class LikesController : ControllerBase
{
    private readonly ILikeRepository _repo;
    public LikesController(ILikeRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _repo.GetByIdAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpGet("post/{postId}")]
    public async Task<IActionResult> GetByPost(int postId) =>
        Ok(await _repo.GetByPostIdAsync(postId));

    [HttpGet("exists/{usuarioId}/{postId}")]
    public async Task<IActionResult> Exists(int usuarioId, int postId) =>
        Ok(await _repo.ExistsAsync(usuarioId, postId));

    [HttpPost]
    public async Task<IActionResult> Create(Like entity)
    {
        await _repo.AddAsync(entity);
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repo.DeleteAsync(id);
        return NoContent();
    }
}

// ─── Seguidor ─────────────────────────────────────────────────────────────────
[ApiController]
[Route("api/[controller]")]
public class SeguidoresController : ControllerBase
{
    private readonly ISeguidorRepository _repo;
    public SeguidoresController(ISeguidorRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _repo.GetByIdAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpGet("siguiendo/{seguidorId}/{seguidoId}")]
    public async Task<IActionResult> IsFollowing(int seguidorId, int seguidoId) =>
        Ok(await _repo.IsFollowingAsync(seguidorId, seguidoId));

    [HttpGet("seguidos/{usuarioId}")]
    public async Task<IActionResult> GetSeguidos(int usuarioId) =>
        Ok(await _repo.GetSeguidosAsync(usuarioId));

    [HttpPost]
    public async Task<IActionResult> Create(Seguidor entity)
    {
        await _repo.AddAsync(entity);
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repo.DeleteAsync(id);
        return NoContent();
    }
}
