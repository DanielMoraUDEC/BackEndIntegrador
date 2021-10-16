using AutoMapper;
using BackEndIntegrador.Models;
using BackEndIntegrador.Models.Dtos;
using BackEndIntegrador.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BackEndIntegrador.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : Controller
    {

        private readonly IUsuarioRepository _usuRepo;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioRepository usuRepo, IMapper mapper)
        {
            _usuRepo = usuRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUsuarios()
        {
            var listaUsuarios = _usuRepo.GetUsuarios();

            var listaUsuariosDto = new List<UsuarioDto>();
            foreach (var lista in listaUsuarios)
            {
                listaUsuariosDto.Add(_mapper.Map<UsuarioDto>(lista));
            }

            return Ok(listaUsuariosDto);
        }


        [HttpGet("{idUsuario:int}", Name = "GetUsuario")]
        public IActionResult GetUsuario(int idUsuario)
        {
            var usuario = _usuRepo.GetUsuario(idUsuario);
            if( usuario == null)
            {
                return NotFound();
            }

            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);

            return Ok(usuarioDto);
        }

        [HttpPost]
        public IActionResult CreateUsuario([FromBody] UsuarioDto usuarioDto)
        {
            if(usuarioDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_usuRepo.ExisteUsuario(usuarioDto.correo))
            {
                ModelState.AddModelError("", "El usuario ya se encuentra registrado");
                return StatusCode(404, ModelState);
            }

            var usuario = _mapper.Map<Usuario>(usuarioDto);

            if (!_usuRepo.CrearUsuario(usuario))
            {
                ModelState.AddModelError("", $"Algo salio mal al registrar el usuario {usuario.nombre}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetUsuario", new { idUsuario = usuario.id_usuario }, usuario);
        }

        [HttpPatch("{idUsuario:int}", Name = "updateUsuario")]
        public IActionResult updateUsuario(int idUsuario, [FromBody] UsuarioDto usuarioDto)
        {
            if(usuarioDto == null || idUsuario != usuarioDto.id_usuario)
            {
                return BadRequest(ModelState);
            }

            var usuario = _mapper.Map<Usuario>(usuarioDto);

            if (!_usuRepo.ActualizarUsuario(usuario))
            {
                ModelState.AddModelError("", $"Algo salio mal al Actualizar el usuario {usuario.nombre}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{idUsuario:int}", Name = "deleteUsuario")]
        public IActionResult deleteUsuario(int idUsuario)
        {

            if (!_usuRepo.ExisteUsuario(idUsuario))
            {
                return NotFound();
            }

            var usuario = _usuRepo.GetUsuario(idUsuario);

            if (!_usuRepo.BorrarUsuario(usuario))
            {
                ModelState.AddModelError("", $"Algo salio mal al Actualizar el usuario {usuario.nombre}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        

    }
}
