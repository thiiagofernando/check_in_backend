using CheckIn.backend.Domain.Entities;
using CheckIn.backend.Domain.Enums;

namespace CheckIn.backend.Domain.Interfaces;

public interface IUsuarioRepository
{
    Task<IEnumerable<Usuario>> GetAllAsync();
    Task<Usuario> GetByIdAsync(long id);
    Task<Usuario> GetByEmailAndTipoUsuarioAsync(string email, TipoUsuario tipoUsuario);
    Task AddAsync(Usuario usuario);
    Task UpdateAsync(Usuario usuario);
    Task DeleteAsync(long id);
    Task<bool> ExistsByEmailAsync(string email);
}