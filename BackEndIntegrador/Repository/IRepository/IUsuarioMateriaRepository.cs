using BackEndIntegrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndIntegrador.Repository.IRepository
{
    public interface IUsuarioMateriaRepository
    {
        ICollection<UsuarioMateria> GetUsuarioMateria();
        UsuarioMateria GetUsuarioMateria(int id_usuariomateria);
        bool ExisteUsuarioMateria(int id_usuariomateria);
        bool CrearUsuarioMateria(UsuarioMateria usuariomateria);
        bool ActualizarUsuarioMateria(UsuarioMateria usuariomateria);
        bool BorrarUsuarioMateria(UsuarioMateria usuariomateria);
        bool Guardar();
    }
}
