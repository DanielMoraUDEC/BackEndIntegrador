using BackEndIntegrador.Data;
using BackEndIntegrador.Models;
using BackEndIntegrador.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndIntegrador.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _bd;

        public UsuarioRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public bool ActualizarUsuario(Usuario usuario)
        {
            _bd.Usuario.Update(usuario);
            return Guardar();
        }

        public bool BorrarUusuario(Usuario usuario)
        {
            _bd.Usuario.Remove(usuario);
            return Guardar();
        }

        public bool CrearUsuario(Usuario usuario)
        {
            _bd.Usuario.Add(usuario);
            return Guardar();
        }

        public bool ExisteUsuario(string correo)
        {
            bool valor = _bd.Usuario.Any(c => c.correo.ToLower().Trim() == correo.ToLower().Trim());
            return valor;
        }

        public bool ExisteUsuario(int id_usuario)
        {
            bool valor = _bd.Usuario.Any(c => c.id_usuario == id_usuario);
            return valor;
        }

        public Usuario GetUsuario(int id_usuario)
        {
            return _bd.Usuario.FirstOrDefault(c => c.id_usuario == id_usuario);
        }

        public ICollection<Usuario> GetUsuarios()
        {
            return _bd.Usuario.OrderBy(c => c.nombre).ToList();
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >=0 ? true:false;
        }
    }
}
