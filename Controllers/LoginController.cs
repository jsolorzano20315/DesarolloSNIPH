
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using PruebaPOPA;

namespace API_PuntoVenta_Sofia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
    
        public LoginController(IConfiguration configuration) 
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        [HttpPost()]
        public async Task<IActionResult> LoginUser(UserLoginDto login) 
        {
            List<UsuariosDto> result;
            var query = new StringBuilder();
            query.AppendLine(StaticResources.QueryUserLogin);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@nombre", login.nombre);
            parameters.Add("@password", login.password);
            using var connection = new System.Data.SqlClient.SqlConnection(Configuration.GetConnectionString("EntitiesContext"));
            result = (await connection.QueryAsync<UsuariosDto>(query.ToString(), parameters)).ToList();
            
            //Autenticar Usuario
            if (result.Count != 0)
            {
                var token = Generate(login);
                return Ok(token);
            }
            return NotFound("usuario no autenticado");  
        }

        private string Generate(UserLoginDto login)
        {
                var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["jwt:key"]));
                var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
                //Crear los claims
                var claims = new[]
                        {
                            new Claim(ClaimTypes.NameIdentifier, login.nombre),
                        };
                //Crear token
                var token = new JwtSecurityToken(
                    Configuration["Jwt: Issuer"],
                    Configuration["Jwt: Audience"],
                    claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);            
        }

        [HttpGet()]
        public IActionResult Jwt() 
        {
            var currentsUser = GetCurrentsUser();
            return Ok(currentsUser);
        }

        private UsuariosDto GetCurrentsUser()
        {
            var idetity = HttpContext.User.Identity as ClaimsIdentity;
            return null;
        }
    }
}
