using AutoMapper;
using DTO.DTO.ApiAdmin;
using DTO.DTO.ApiAuth;
using Repository.Models;


namespace Configuraciones
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApiAdminEmpleado, EmpleadoDTO>().ReverseMap();
            CreateMap<ApiAuthUsuario, UsuarioDTO>().ReverseMap();
        }
    }
}
