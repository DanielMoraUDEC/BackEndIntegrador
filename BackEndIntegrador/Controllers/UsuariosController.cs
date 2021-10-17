using AutoMapper;
using BackEndIntegrador.Models;
using BackEndIntegrador.Models.Dtos;
using BackEndIntegrador.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;

namespace BackEndIntegrador.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : Controller
    {

        private readonly IUsuarioRepository _usuRepo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UsuariosController(IUsuarioRepository usuRepo, IMapper mapper, IConfiguration config)
        {
            _usuRepo = usuRepo;
            _mapper = mapper;
            _config = config;
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

        [HttpPost]
        [Route("registro")]
        public IActionResult Registro(UsuarioAuthDto usuario)
        {
            usuario.correo = usuario.correo.ToLower();

            if (_usuRepo.ExisteUsuario(usuario.correo))
            {
                return BadRequest("El correo ya está registrado");
            }

            var nuevoUsuario = new Usuario
            {
                nombre = usuario.nombre,
                apellido = usuario.apellido,
                celular = usuario.celular,
                correo = usuario.correo,
                contraseña = usuario.contraseña,
                es_tutor = false,
                rol = 2,
                is_mail_confirmed = false,
                activation_code = Guid.NewGuid(),
                can_publicaciones = 0
            };

            var newCreatedUser = _usuRepo.Registro(nuevoUsuario, usuario.contraseña);

            SendVerificationLinkEmail(usuario.correo, nuevoUsuario.activation_code.ToString());

            return Ok(newCreatedUser);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(UsuarioAuthLoginDto usuario)
        {
            var usuarioLogin = _usuRepo.Login(usuario.correo, usuario.contraseña);

            if (usuarioLogin == null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuarioLogin.id_usuario.ToString()),
                new Claim(ClaimTypes.Name, usuarioLogin.correo.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { 
                token = tokenHandler.WriteToken(token)
            });
        }

        /*[HttpPatch("{idUsuario:int}", Name = "updateUsuario")]
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
        }*/

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
        
        [NonAction]
        private void SendVerificationLinkEmail(string emailID, string ActivationCode)
        {
            var verifyUrl = "/UsuariosControllerMVC/userVerification/" + ActivationCode;
            var link = Request.Host + verifyUrl;

            var fromEmail = new MailAddress("udecChanges@gmail.com");
            var fromEmailPass = "SUPERingenieros";
            var toEmail = new MailAddress(emailID);
            string subject = "Su cuenta ha sido exitosamente activada";

            string body = "<br/><h1>HuertBog</h1><br/>Gracias por registrarse en la página, ahora tiene acceso a más funciones" +
                " como publicar información general o publicar información con respecto a solicitudes u ofrecimientos" +
                " de servicios o productos, recuerde publicar contenido con respecto a las huertas y mantenerse apegado" +
                "a las normas de la comunidad. Por favor haga click en el link de abajo para terminar de verificar su cuenta " +
                "<br/><br/><a href='https://" + link + "'>" + link + "</a>";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPass)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })

                smtp.Send(message);
        }
    }
}
