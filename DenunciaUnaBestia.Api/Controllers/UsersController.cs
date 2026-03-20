using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DenunciaUnaBestia.Api.Data;
using DenunciaUnaBestia.Api.Models.Entities;
using DenunciaUnaBestia.Api.Models.Dtos;

namespace DenunciaUnaBestia.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UsersController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
    {
        var users = await _context.Users.ToListAsync();
        var dtos = users.Select(u => new UserDto
        {
            Id = u.Id,
            Username = u.Username,
            Email = u.Email,
            FullName = u.FullName,
            IsActive = u.IsActive
        }).ToList();
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetById(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return NotFound();
        var dto = new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            FullName = user.FullName,
            IsActive = user.IsActive
        };
        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> Create([FromBody] CreateUserDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Username))
            return BadRequest("El nombre de usuario es obligatorio.");

        if (string.IsNullOrWhiteSpace(dto.Email))
            return BadRequest("El email es obligatorio.");

        var entity = new User
        {
            Username = dto.Username,
            Email = dto.Email,
            FullName = dto.FullName,
            IsActive = true
        };

        _context.Users.Add(entity);
        await _context.SaveChangesAsync();

        var responseDto = new UserDto
        {
            Id = entity.Id,
            Username = entity.Username,
            Email = entity.Email,
            FullName = entity.FullName,
            IsActive = entity.IsActive
        };

        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, responseDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CreateUserDto dto)
    {
        var entity = await _context.Users.FindAsync(id);
        if (entity == null) return NotFound();

        if (string.IsNullOrWhiteSpace(dto.Username))
            return BadRequest("El nombre de usuario es obligatorio.");

        if (string.IsNullOrWhiteSpace(dto.Email))
            return BadRequest("El email es obligatorio.");

        entity.Username = dto.Username;
        entity.Email = dto.Email;
        entity.FullName = dto.FullName;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var entity = await _context.Users.FindAsync(id);
        if (entity == null) return NotFound();

        _context.Users.Remove(entity);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}           