using MediatR;

namespace CheckIn.backend.Application.Commands.AtualizarUsuarioCommand;

public class AtualizarUsuarioCommand : IRequest<bool>
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
}
