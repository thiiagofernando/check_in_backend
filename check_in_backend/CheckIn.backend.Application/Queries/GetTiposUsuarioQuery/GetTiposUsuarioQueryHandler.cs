using CheckIn.backend.Domain.Enums;
using MediatR;

namespace CheckIn.backend.Application.Queries.GetTiposUsuarioQuery;

public class GetTiposUsuarioQueryHandler : IRequestHandler<GetTiposUsuarioQuery, IEnumerable<TipoUsuarioDto>>
{
    public Task<IEnumerable<TipoUsuarioDto>> Handle(GetTiposUsuarioQuery request, CancellationToken cancellationToken)
    {
        var tiposUsuario = Enum.GetValues(typeof(TipoUsuario))
            .Cast<TipoUsuario>()
            .Select(t => new TipoUsuarioDto { Id = (int)t, Nome = t.ToString() });

        return Task.FromResult(tiposUsuario);
    }
}
