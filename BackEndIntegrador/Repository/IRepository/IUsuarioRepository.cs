using BackEndIntegrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndIntegrador.Repository.IRepository
{
    public interface IUsuarioRepository
    {
        ICollection<Usuario> GetUsuarios();

        Usuario GetUsuario(int id_usuario);

        bool ExisteUsuario(string correo);

        bool ExisteUsuario(int id_usuario);

        bool CrearUsuario(Usuario usuario);

        Usuario Registro(Usuario usuario, string password);

        Usuario Login(string correo, string password);

        bool ActualizarUsuario(Usuario usuario);

        bool BorrarUsuario(Usuario usuario);

        bool Guardar();


    }
}
