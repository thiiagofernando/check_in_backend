using System.Security.Cryptography;
using System.Text;
using CheckIn.backend.Domain.Interfaces;
using MediatR;

namespace CheckIn.backend.Application.Commands.AtualizarUsuarioCommand;

public class AtualizarUsuarioCommandHandler : IRequestHandler<AtualizarUsuarioCommand, bool>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public AtualizarUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<bool> Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuarioExistente = await _usuarioRepository.GetByIdAsync(request.Id);
        if (usuarioExistente == null)
        {
            throw new Exception("Usuário não encontrado.");
        }

        usuarioExistente.Nome = request.Nome;
        usuarioExistente.Telefone = request.Telefone;
        usuarioExistente.Email = request.Email;
        usuarioExistente.Senha = HashPassword(request.Senha); // Implementar o método de hash MD5

        await _usuarioRepository.UpdateAsync(usuarioExistente);
        return true;
    }

    private string HashPassword(string password)
    {
        using (var md5 = MD5.Create())
        {
            var inputBytes = Encoding.UTF8.GetBytes(password);
            var hashBytes = md5.ComputeHash(inputBytes);
            return Convert.ToHexString(hashBytes);
        }
    }
}
