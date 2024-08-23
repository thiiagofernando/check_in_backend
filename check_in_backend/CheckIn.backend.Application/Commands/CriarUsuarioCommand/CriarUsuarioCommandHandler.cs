using CheckIn.backend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIn.backend.Domain.Interfaces;

namespace CheckIn.backend.Application.Commands.CriarUsuarioCommand
{
    public class CriarUsuarioCommandHandler : IRequestHandler<CriarUsuarioCommand, bool>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public CriarUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = new Usuario
            {
                Nome = request.UsuarioDto.Nome,
                Telefone = request.UsuarioDto.Telefone,
                Email = request.UsuarioDto.Email,
                TipoUsuario = request.UsuarioDto.TipoUsuario,
                Ativo = true
            };

            usuario.SetSenha(request.UsuarioDto.Senha);

            await _usuarioRepository.AddAsync(usuario);
            return true;
        }
    }
}
