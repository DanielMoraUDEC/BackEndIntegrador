using AutoMapper;
using BackEndIntegrador.Models;
using BackEndIntegrador.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndIntegrador.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
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
