using AutoMapper;
using BackEndIntegrador.Models;
using BackEndIntegrador.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndIntegrador.Mapper
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
        }

    }
}
