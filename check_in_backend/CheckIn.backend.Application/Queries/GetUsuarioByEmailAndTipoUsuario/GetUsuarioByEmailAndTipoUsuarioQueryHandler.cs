using CheckIn.backend.Application.Dto;
using CheckIn.backend.Domain.Interfaces;
using MediatR;

namespace CheckIn.backend.Application.Queries.GetUsuarioByEmailAndTipoUsuario;

public class GetUsuarioByEmailAndTipoUsuarioQueryHandler : IRequestHandler<GetUsuarioByEmailAndTipoUsuarioQuery, UsuarioDto>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public GetUsuarioByEmailAndTipoUsuarioQueryHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<UsuarioDto> Handle(GetUsuarioByEmailAndTipoUsuarioQuery request, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.GetByEmailAndTipoUsuarioAsync(request.Email, request.TipoUsuario);
        
        if (usuario == null)
        {
            throw new Exception("Usuário não encontrado.");
        }

        return new UsuarioDto
        {
            Email = usuario.Email,
            Senha = usuario.Senha
        };
    }
}