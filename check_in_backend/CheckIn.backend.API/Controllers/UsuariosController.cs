using CheckIn.backend.Application.Commands.AtualizarUsuarioCommand;
using CheckIn.backend.Application.Commands.CriarUsuarioCommand;
using CheckIn.backend.Application.Commands.LoginCommand;
using CheckIn.backend.Application.Dto;
using CheckIn.backend.Application.Queries.GetTiposUsuarioQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CheckIn.backend.API.Controllers;

public class UsuariosController : ControllerBase
{
    private readonly IMediator _mediator;
    public UsuariosController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> CriarUsuario([FromBody] UsuarioDto usuarioDto)
    {
        var command = new CriarUsuarioCommand(usuarioDto);
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(CriarUsuario), new { id = result }, usuarioDto);
    }
    [HttpGet("tipos-usuario")]
    public async Task<IActionResult> GetTiposUsuario()
    {
        var tiposUsuario = await _mediator.Send(new GetTiposUsuarioQuery());
        return Ok(tiposUsuario);
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var token = await _mediator.Send(command);
            return Ok(new { Token = token, Expiration = DateTime.UtcNow.AddHours(8) });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized("Credenciais inválidas.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [Authorize]
    [HttpPut("atualizar/{id}")]
    public async Task<IActionResult> AtualizarUsuario(long id, [FromBody] AtualizarUsuarioCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);
        return Ok("Usuário atualizado com sucesso.");
    }
}