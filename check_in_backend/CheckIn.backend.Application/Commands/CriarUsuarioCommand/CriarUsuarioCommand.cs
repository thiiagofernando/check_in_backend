using CheckIn.backend.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.backend.Application.Commands.CriarUsuarioCommand
{
    public class CriarUsuarioCommand : IRequest<bool>
    {
        public UsuarioDto UsuarioDto { get; }

        public CriarUsuarioCommand(UsuarioDto usuarioDto)
        {
            UsuarioDto = usuarioDto;
        }
    }
}
