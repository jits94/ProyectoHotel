using AutoMapper;
using Proyecto.DTOs;
using Proyecto.Models;

namespace Proyecto.Helper
{
    public class AutoMapperProfile: Profile

    {
        public AutoMapperProfile()
        {
            //get
            CreateMap<Persona, PersonaDTO>();
            //post
            CreateMap<InsertarPersonaDTO, Persona>();

            //get
            CreateMap<Rol, RolDTO>();
            //post
            CreateMap<insertarRolDTO, Rol> ();

            //get
            CreateMap<Casa, CasaDTO>();
            //post
            CreateMap<InsertarCasaDTO, Casa>();
        }

    }
}
