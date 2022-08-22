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

        public async Task Delete(int id)
        {
            var entity = await _context.Direcciones.FirstOrDefaultAsync(x => x.IdDireccion == id);

            if (entity != null)
            {
                _context.Direcciones.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Direcciones>> GetAll()
        {
            var lista = await _context.Direcciones.ToListAsync();
            return lista;
        }

        public async Task<Direcciones> GetById(int id)
        {
            return await _context.Direcciones.FirstOrDefaultAsync(x => x.IdDireccion == id);
        }

        public async Task Update(Direcciones entity)
        {
            _context.Direcciones.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
