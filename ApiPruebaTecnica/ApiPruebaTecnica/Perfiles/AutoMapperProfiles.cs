using ApiPruebaTecnica.Models;
using ApiPruebaTecnica.Models.DTO;
using AutoMapper;

namespace ApiPruebaTecnica.Perfiles
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<Direcciones, DireccionesDTO>();
            CreateMap<DireccionesDTO, Direcciones>();
            CreateMap<DireccionesDTO, DireccionesMostrarDTO>();
        }
    }
}
