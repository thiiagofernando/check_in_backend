using CheckIn.backend.Application.Dto;
using CheckIn.backend.Domain.Enums;
using MediatR;

namespace CheckIn.backend.Application.Queries.GetUsuarioByEmailAndTipoUsuario;

public class GetUsuarioByEmailAndTipoUsuarioQuery : IRequest<UsuarioDto>
{
    public string Email { get; set; }
    public TipoUsuario TipoUsuario { get; set; }
}