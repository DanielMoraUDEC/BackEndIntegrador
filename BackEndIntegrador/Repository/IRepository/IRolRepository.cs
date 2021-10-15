using BackEndIntegrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndIntegrador.Repository.IRepository
{
    public interface IRolRepository
    {
        ICollection<Rol> getRol();

        Rol getRol(int id_rol);

        bool existeRol(string nombre);

        bool existeRol(int id_rol);

        bool crearRol(Rol rol);

        bool actualizarRol(Rol rol);

        bool borrarRol(Rol rol);

        bool Guardar();
    }
}
