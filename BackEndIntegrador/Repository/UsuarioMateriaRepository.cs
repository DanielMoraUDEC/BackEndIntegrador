using BackEndIntegrador.Data;
using BackEndIntegrador.Models;
using BackEndIntegrador.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndIntegrador.Repository
{
    public class UsuarioMateriaRepository : IUsuarioMateriaRepository
    {
        private readonly ApplicationDbContext _bd;

        public UsuarioMateriaRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public bool ActualizarUsuarioMateria(UsuarioMateria usuariomateria)
        {
            _bd.UsuarioMateria.Update(usuariomateria);
            return Guardar();
        }

        public bool BorrarUsuarioMateria(UsuarioMateria usuariomateria)
        {
            _bd.UsuarioMateria.Remove(usuariomateria);
            return Guardar();
        }

        public bool CrearUsuarioMateria(UsuarioMateria usuariomateria)
        {
            _bd.UsuarioMateria.Add(usuariomateria);
            return Guardar();
        }

        public bool ExisteUsuarioMateria(int id_usuariomateria)
        {
            bool valor = _bd.UsuarioMateria.Any(um => um.id_usuario_materia == id_usuariomateria);
            return valor;
        }

        public ICollection<UsuarioMateria> GetUsuarioMateria()
        {
            return _bd.UsuarioMateria.OrderBy(um => um.id_usuario_materia).ToList();
        }

        public UsuarioMateria GetUsuarioMateria(int id_usuariomateria)
        {
            return _bd.UsuarioMateria.FirstOrDefault(um => um.id_usuario_materia == id_usuariomateria);
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
