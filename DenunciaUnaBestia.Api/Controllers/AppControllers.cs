using Microsoft.AspNetCore.Mvc;
using DenunciaUnaBestia.Application.Contract;
using DenunciaUnaBestia.Application.Dtos.Usuario;
using DenunciaUnaBestia.Application.Dtos.Post;
using DenunciaUnaBestia.Application.Dtos.Comentario;
using DenunciaUnaBestia.Application.Dtos.Like;
using DenunciaUnaBestia.Application.Dtos.Seguidor;

namespace DenunciaUnaBestia.Api.Controllers;

// ─── Usuarios ────────────────────────────────────────────────────────────────
[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _service;
    public UsuariosController(IUsuarioService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return result.Success ? Ok(result.Data) : BadRequest(result.Message);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return result.Success ? Ok(result.Data) : NotFound(result.Message);
    }

    [HttpGet("email/{email}")]
    public async Task<IActionResult> GetByEmail(string email)
    {
        var result = await _service.GetByEmailAsync(email);
        return result.Success ? Ok(result.Data) : NotFound(result.Message);
    }

    [HttpGet("{id}/seguidores")]
    public async Task<IActionResult> GetSeguidores(int id)
    {
        var result = await _service.GetSeguidoresAsync(id);
        return result.Success ? Ok(result.Data) : BadRequest(result.Message);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUsuarioDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return result.Success ? Ok(result.Message) : BadRequest(result.Message);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateUsuarioDto dto)
    {
        var result = await _service.UpdateAsync(id, dto);
        return result.Success ? Ok(result.Message) : BadRequest(result.Message);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        return result.Success ? Ok(result.Message) : BadRequest(result.Message);
    }
}

// ─── Posts ───────────────────────────────────────────────────────────────────
[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostService _service;
    public PostsController(IPostService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return result.Success ? Ok(result.Data) : BadRequest(result.Message);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return result.Success ? Ok(result.Data) : NotFound(result.Message);
    }

    [HttpGet("usuario/{usuarioId}")]
    public async Task<IActionResult> GetByUsuario(int usuarioId)
    {
        var result = await _service.GetByUsuarioIdAsync(usuarioId);
        return result.Success ? Ok(result.Data) : BadRequest(result.Message);
    }

    [HttpGet("feed/{usuarioId}")]
    public async Task<IActionResult> GetFeed(int usuarioId)
    {
        var result = await _service.GetFeedAsync(usuarioId);
        return result.Success ? Ok(result.Data) : BadRequest(result.Message);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePostDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return result.Success ? Ok(result.Message) : BadRequest(result.Message);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreatePostDto dto)
    {
        var result = await _service.UpdateAsync(id, dto);
        return result.Success ? Ok(result.Message) : BadRequest(result.Message);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        return result.Success ? Ok(result.Message) : BadRequest(result.Message);
    }
}

// ─── Comentarios ─────────────────────────────────────────────────────────────
[ApiController]
[Route("api/[controller]")]
public class ComentariosController : ControllerBase
{
    private readonly IComentarioService _service;
    public ComentariosController(IComentarioService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return result.Success ? Ok(result.Data) : BadRequest(result.Message);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return result.Success ? Ok(result.Data) : NotFound(result.Message);
    }

    [HttpGet("post/{postId}")]
    public async Task<IActionResult> GetByPost(int postId)
    {
        var result = await _service.GetByPostIdAsync(postId);
        return result.Success ? Ok(result.Data) : BadRequest(result.Message);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateComentarioDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return result.Success ? Ok(result.Message) : BadRequest(result.Message);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateComentarioDto dto)
    {
        var result = await _service.UpdateAsync(id, dto);
        return result.Success ? Ok(result.Message) : BadRequest(result.Message);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        return result.Success ? Ok(result.Message) : BadRequest(result.Message);
    }
}

// ─── Likes ───────────────────────────────────────────────────────────────────
[ApiController]
[Route("api/[controller]")]
public class LikesController : ControllerBase
{
    private readonly ILikeService _service;
    public LikesController(ILikeService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return result.Success ? Ok(result.Data) : BadRequest(result.Message);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return result.Success ? Ok(result.Data) : NotFound(result.Message);
    }

    [HttpGet("post/{postId}")]
    public async Task<IActionResult> GetByPost(int postId)
    {
        var result = await _service.GetByPostIdAsync(postId);
        return result.Success ? Ok(result.Data) : BadRequest(result.Message);
    }

    [HttpGet("exists/{usuarioId}/{postId}")]
    public async Task<IActionResult> Exists(int usuarioId, int postId)
    {
        var result = await _service.ExistsAsync(usuarioId, postId);
        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateLikeDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return result.Success ? Ok(result.Message) : BadRequest(result.Message);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        return result.Success ? Ok(result.Message) : BadRequest(result.Message);
    }
}

// ─── Seguidores ──────────────────────────────────────────────────────────────
[ApiController]
[Route("api/[controller]")]
public class SeguidoresController : ControllerBase
{
    private readonly ISeguidorService _service;
    public SeguidoresController(ISeguidorService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return result.Success ? Ok(result.Data) : BadRequest(result.Message);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return result.Success ? Ok(result.Data) : NotFound(result.Message);
    }

    [HttpGet("siguiendo/{seguidorId}/{seguidoId}")]
    public async Task<IActionResult> IsFollowing(int seguidorId, int seguidoId)
    {
        var result = await _service.IsFollowingAsync(seguidorId, seguidoId);
        return Ok(result.Data);
    }

    [HttpGet("seguidos/{usuarioId}")]
    public async Task<IActionResult> GetSeguidos(int usuarioId)
    {
        var result = await _service.GetSeguidosAsync(usuarioId);
        return result.Success ? Ok(result.Data) : BadRequest(result.Message);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSeguidorDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return result.Success ? Ok(result.Message) : BadRequest(result.Message);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        return result.Success ? Ok(result.Message) : BadRequest(result.Message);
    }
}
