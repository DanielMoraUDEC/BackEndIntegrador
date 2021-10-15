using BackEndIntegrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndIntegrador.Repository.IRepository
{
    public interface IPublicacionRepository
    {
        ICollection<Publicacion> GetPublicacion();
        Publicacion GetPublicacion(int id_publicacion);
        bool ExistePublicacion(int id_publicacion);
        bool CrearPublicacion(Publicacion publicacion);
        bool ActualizarPublicacion(Publicacion publicacion);
        bool BorrarPublicacion(Publicacion publicacion);
        bool Guardar();

    }
}
