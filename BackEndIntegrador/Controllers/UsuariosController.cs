using AutoMapper;
using BackEndIntegrador.Models.Dtos;
using BackEndIntegrador.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndIntegrador.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : Controller
    {

        private readonly IUsuarioRepository _usuRepo;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioRepository usuRepo, IMapper mapper )
        {
            _usuRepo = usuRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUsuario()
        {
            var listaUsuarios = _usuRepo.GetUsuarios();

            var listaUsuariosDto = new List<UsuarioDto>();
            foreach (var lista in listaUsuarios)
            {
                listaUsuariosDto.Add(_mapper.Map<UsuarioDto>(lista));
            }

            return Ok(listaUsuariosDto);
        }
    }
}
