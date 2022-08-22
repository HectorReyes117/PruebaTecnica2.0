using ApiPruebaTecnica.Interfaces;
using ApiPruebaTecnica.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebaTecnica.Services
{
    public class DireccionesServices : IRepository<Direcciones>
    {
        private readonly PruebaTecnicaContext _context;

        public DireccionesServices(PruebaTecnicaContext context)
        {
            _context = context;
        }

        public async Task Add(Direcciones entity)
        {
           await _context.Direcciones.AddAsync(entity);
          await  _context.SaveChangesAsync();    
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Direcciones>> GetAll()
        {
            var lista = await _context.Direcciones.ToListAsync();
            return lista;
        }

        public Task<Direcciones> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Direcciones entity)
        {
            throw new NotImplementedException();
        }
    }
}
