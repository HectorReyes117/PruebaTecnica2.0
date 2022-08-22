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

        [HttpPut]
        public async Task<IActionResult> Editar([FromBody] Direcciones entidad)
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

        [HttpDelete]
        public async Task<IActionResult> Borrar([FromBody] int id)
        {
            if (id != null)
            {
                await _context.Delete(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("buscarDirecciones")]
        public async Task<IActionResult> buscarDirecciones(int id)
        {
            return Ok(await _context.GetById(id));
        }


    }
}
