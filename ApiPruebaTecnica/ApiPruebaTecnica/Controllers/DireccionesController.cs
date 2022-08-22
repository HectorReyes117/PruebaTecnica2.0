using ApiPruebaTecnica.Interfaces;
using ApiPruebaTecnica.Models;
using ApiPruebaTecnica.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DireccionesController : ControllerBase
    {
        private readonly IRepository<Direcciones> _context;
        private readonly IMapper _mapper;

        public DireccionesController(IRepository<Direcciones> context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task< IActionResult> ObtenerTodo()
        {
            return Ok(await _context.GetAll()); 
        }

        [HttpPost]
        public async Task<IActionResult> Guardar([FromBody] DireccionesDTO entidad)
        {
            if (entidad != null)
            {
                var direccion = _mapper.Map<Direcciones>(entidad);
                await _context.Add(direccion);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


    }
}
