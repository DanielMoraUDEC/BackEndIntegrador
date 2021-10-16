using AutoMapper;
using BackEndIntegrador.Models;
using BackEndIntegrador.Models.Dtos;

namespace BackEndIntegrador.Mapper
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Publicacion, PublicacionDto>().ReverseMap();
            CreateMap<Materia, MateriaDto>().ReverseMap();
            CreateMap<Tema, TemaDto>().ReverseMap();
            CreateMap<UsuarioMateria, UsuarioMateriaDto>().ReverseMap();
            CreateMap<Rol, RolDto>().ReverseMap();
        }

    }
}
