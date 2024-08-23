using MediatR;

namespace CheckIn.backend.Application.Queries.GetTiposUsuarioQuery;

public class GetTiposUsuarioQuery : IRequest<IEnumerable<TipoUsuarioDto>>
{
}

public class TipoUsuarioDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
}