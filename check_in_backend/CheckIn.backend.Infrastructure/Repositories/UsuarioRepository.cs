using System.Data;
using CheckIn.backend.Domain.Entities;
using CheckIn.backend.Domain.Enums;
using CheckIn.backend.Domain.Interfaces;
using Dapper;

namespace CheckIn.backend.Infrastructure.Repositories
{
     public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDbConnection _dbConnection;

        public UsuarioRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            string query = "SELECT * FROM Usuarios";
            return await _dbConnection.QueryAsync<Usuario>(query);
        }

        public async Task<Usuario> GetByIdAsync(long id)
        {
            string query = "SELECT * FROM Usuarios WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Usuario>(query, new { Id = id });
        }

        public async Task<Usuario> GetByEmailAndTipoUsuarioAsync(string email, TipoUsuario tipoUsuario)
        {
            string query = "SELECT * FROM Usuarios WHERE Email = @Email AND TipoUsuario = @TipoUsuario";
            return await _dbConnection.QueryFirstOrDefaultAsync<Usuario>(query, new { Email = email, TipoUsuario = tipoUsuario });
        }

        public async Task AddAsync(Usuario usuario)
        {
            string query = @"INSERT INTO Usuarios (Nome, Telefone, Email, Senha, TipoUsuario, Ativo, CriadoEm) 
                             VALUES (@Nome, @Telefone, @Email, @Senha, @TipoUsuario, @Ativo, @CriadoEm)";
            await _dbConnection.ExecuteAsync(query, usuario);
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            string query = @"UPDATE Usuarios SET Nome = @Nome, Telefone = @Telefone, Email = @Email, 
                             Senha = @Senha, TipoUsuario = @TipoUsuario, Ativo = @Ativo WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(query, usuario);
        }

        public async Task DeleteAsync(long id)
        {
            string query = "DELETE FROM Usuarios WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(query, new { Id = id });
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            string query = "SELECT COUNT(1) FROM Usuarios WHERE Email = @Email";
            return await _dbConnection.ExecuteScalarAsync<bool>(query, new { Email = email });
        }
    }

}
