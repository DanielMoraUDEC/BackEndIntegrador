using BackEndIntegrador.Data;
using BackEndIntegrador.Models;
using BackEndIntegrador.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndIntegrador.Repository
{
    public class RolRepository: IRolRepository
    {
        private readonly ApplicationDbContext _bd;
        public RolRepository(ApplicationDbContext db)
        {
            _bd = db;
        }

        public bool actualizarRol(Rol rol)
        {
            _bd.Rol.Update(rol);
            return Guardar();
        }

        public bool borrarRol(Rol rol)
        {
            _bd.Rol.Remove(rol);
            return Guardar();
        }

        public bool crearRol(Rol rol)
        {
            _bd.Rol.Add(rol);
            return Guardar();
        }

        public bool existeRol(string nombre)
        {
            bool valor = _bd.Rol.Any(m => m.nombre.ToLower().Trim() == nombre.ToLower().Trim());
            return valor;
        }

        public bool existeRol(int id_rol)
        {
            return _bd.Rol.Any(c => c.id_rol == id_rol);
        }

        public ICollection<Rol> getRol()
        {
            return _bd.Rol.OrderByDescending(c => c.nombre).ToList();
        }

        public Rol getRol(int id_rol)
        {
            return _bd.Rol.FirstOrDefault(c => c.id_rol == id_rol);
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
        
    }
}
