using CheckIn.backend.Domain.Enums;
using MediatR;

namespace CheckIn.backend.Application.Commands.LoginCommand;

public class LoginCommand : IRequest<string>
{
    public string Email { get; set; }
    public string Senha { get; set; }
    public TipoUsuario TipoUsuario { get; set; }
}
