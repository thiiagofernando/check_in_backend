using System.Security.Claims;
using CheckIn.backend.Application.Commands.UpdateHorarioTreinoCommand;
using CheckIn.backend.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CheckIn.backend.API.Controllers;

public class HorariosTreinoController : ControllerBase
{
    [Authorize]
    [HttpPut("atualizar/{id}")]
    public async Task<IActionResult> AtualizarHorarioTreino(long id, [FromBody] UpdateHorarioTreinoCommand command)
    {
        // Verifique se o usuário é um instrutor antes de permitir o acesso
        var usuarioTipo = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
        if (usuarioTipo != TipoUsuario.Instrutor.ToString())
        {
            return Forbid();
        }

        command.Id = id;
        await _mediator.Send(command);
        return Ok("Horário de treino atualizado com sucesso.");
    }
}