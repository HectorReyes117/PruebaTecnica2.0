using ApiPruebaTecnica.Interfaces;
using ApiPruebaTecnica.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogin login;

        public LoginController(ILogin login)
        {
            this.login = login;
        }

        [HttpPost]
        public IActionResult Login([FromBody] UsuarioLoginDTO usuario)
        {
            if(usuario != null)
            {
                var token = login.Login(usuario.nombreUsuario, usuario.clave);

                return StatusCode(StatusCodes.Status200OK, new { token = token });
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            
        }
    }
}
