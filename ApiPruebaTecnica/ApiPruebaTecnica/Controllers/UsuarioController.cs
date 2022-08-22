using ApiPruebaTecnica.Interfaces;
using ApiPruebaTecnica.Models;
using ApiPruebaTecnica.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaTecnica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IRepository<Usuario> _context;
        private readonly IMapper _mapper;

        public UsuarioController(IRepository<Usuario> context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodo()
        {
            return Ok(await _context.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> Guardar([FromBody] UsuarioDTO entidad)
        {
            if(entidad != null)
            {
                var usuario = _mapper.Map<Usuario>(entidad);
                await _context.Add(usuario);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        public async Task<IActionResult> Editar([FromBody] Usuario entidad)
        {
            if (entidad != null)
            {
                await _context.Update(entidad);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


       


    }
}
