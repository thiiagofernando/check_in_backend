using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using CheckIn.backend.Domain.Entities;
using CheckIn.backend.Domain.Interfaces;
using MediatR;

namespace CheckIn.backend.Application.Commands.LoginCommand;

public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IConfiguration _configuration;

    public LoginCommandHandler(IUsuarioRepository usuarioRepository, IConfiguration configuration)
    {
        _usuarioRepository = usuarioRepository;
        _configuration = configuration;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.GetByEmailAndTipoUsuarioAsync(request.Email, request.TipoUsuario);
        
        if (usuario == null || usuario.Senha != HashPassword(request.Senha))
        {
            throw new UnauthorizedAccessException("Credenciais inválidas.");
        }

        var token = GenerateJwtToken(usuario);
        return token;
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

    private string GenerateJwtToken(Usuario usuario)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, usuario.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, usuario.TipoUsuario.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(8),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
