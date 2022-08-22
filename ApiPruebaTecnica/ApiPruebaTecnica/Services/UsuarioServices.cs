using ApiPruebaTecnica.Interfaces;
using ApiPruebaTecnica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiPruebaTecnica.Services
{
    public class UsuarioServices : IRepository<Usuario>,ILogin
    {
        private readonly PruebaTecnicaContext _context;
        private readonly string secretKey;
        public UsuarioServices(PruebaTecnicaContext context, IConfiguration config)
        {
            _context = context;
            secretKey = config.GetSection("settings").GetSection("secretkey").ToString();
        }

        public async Task Add(Usuario entity)
        {
            await _context.Usuarios.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == id);

            if(entity != null)
            {
                _context.Usuarios.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            var lista = await _context.Usuarios.Include(x=>x.Direcciones).ToListAsync();
            return lista;
        }

        public async Task<Usuario> GetById(int id)
        {

            return await _context.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == id);
        }

        public string Login(string? nombreUsuario, string? clave)
        {
            if(_context.Usuarios.FirstOrDefault(x=> x.NombreUsuario == nombreUsuario && x.Clave == clave) != null)
            {
                var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, nombreUsuario));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                string tokencreado = tokenHandler.WriteToken(tokenConfig);
                return tokencreado;
            }
            else
            {
                return "";
            }
        }

        public async Task Update(Usuario entity)
        {
            _context.Usuarios.Update(entity);
         await _context.SaveChangesAsync();
        }
    }
}
