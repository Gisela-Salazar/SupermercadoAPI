using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Supermercado.Entidades;
using Supermercado.LogicaNegocio;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Supermercado.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UsuarioBL _usuarioBL;
        private readonly IConfiguration _config;

        public AuthController(UsuarioBL usuarioBL, IConfiguration config)
        {
            _usuarioBL = usuarioBL;
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario userLogin)
        {
            var usuario = _usuarioBL.Login(userLogin.Username, userLogin.PasswordHash);

            if (usuario == null) return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.Username),
                new Claim(ClaimTypes.Role, usuario.Rol)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds);

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}