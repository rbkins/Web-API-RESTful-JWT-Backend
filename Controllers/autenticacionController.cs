using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebapiproductoJWT.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;


namespace WebapiproductoJWT.Controllers
{
    [Route("api/[controller]")]
    
    [ApiController]
    public class autenticacionController : ControllerBase
    {
        private readonly string secretkey;

        public autenticacionController(IConfiguration config) {

            secretkey = config.GetSection("settings").GetSection("secretkey").ToString();
        
        
        }
        [HttpPost]
        [Route("validar")]
        public IActionResult validar([FromBody] usuarioModel usuario) {

            if (usuario.correo == "maganaperazadaniel@gmail.com" && usuario.clave == "daniel99")
            {

                var keybytes = Encoding.ASCII.GetBytes(secretkey);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.correo));

                var tokendescriptor = new SecurityTokenDescriptor
                {

                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keybytes), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenhandler = new JwtSecurityTokenHandler();
                var tokenconfig = tokenhandler.CreateToken(tokendescriptor);
                string tokecreado = tokenhandler.WriteToken(tokenconfig);
                return StatusCode(StatusCodes.Status200OK, new { token = tokecreado });


            }
            else {

                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
            
            }


        }
    }
}
