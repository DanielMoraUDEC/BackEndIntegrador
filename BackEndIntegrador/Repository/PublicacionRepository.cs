using BackEndIntegrador.Data;
using BackEndIntegrador.Models;
using BackEndIntegrador.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndIntegrador.Repository
{
    public class PublicacionRepository : IPublicacionRepository
    {
        private readonly ApplicationDbContext _bd;

        public PublicacionRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public bool ActualizarPublicacion(Publicacion publicacion)
        {
            _bd.Publicacion.Update(publicacion);
            return Guardar();
        }

        public bool BorrarPublicacion(Publicacion publicacion)
        {
            _bd.Publicacion.Remove(publicacion);
            return Guardar();
        }

        public bool CrearPublicacion(Publicacion publicacion)
        {
            _bd.Publicacion.Add(publicacion);
            return Guardar();
        }

        public bool ExistePublicacion(int id_publicacion)
        {
            bool valor = _bd.Publicacion.Any(p => p.id_publicacion == id_publicacion);
            return valor;
        }

        public ICollection<Publicacion> GetPublicacion()
        {
            return _bd.Publicacion.OrderBy(p => p.id_publicacion).ToList();
        }

        public Publicacion GetPublicacion(int id_publicacion)
        {
            return _bd.Publicacion.FirstOrDefault(p => p.id_publicacion == id_publicacion);
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
