using BackEndIntegrador.Data;
using BackEndIntegrador.Models;
using BackEndIntegrador.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndIntegrador.Repository
{
    public class MateriaRepository : IMateriaRepository
    {
        private readonly ApplicationDbContext _bd;
        public MateriaRepository(ApplicationDbContext db)
        {
            _bd = db;
        }
        public bool actualizarMateria(Materia materia)
        {
            _bd.Materia.Update(materia);
            return Guardar();
        }

        public bool borrarMateria(Materia materia)
        {
            _bd.Materia.Remove(materia);
            return Guardar();
        }

        public bool crearMateria(Materia materia)
        {
            _bd.Materia.Add(materia);
            return Guardar();
        }

        public bool existeMateria(string Materia)
        {
            bool valor = _bd.Materia.Any(m=>m.nombre.ToLower().Trim()==Materia.ToLower().Trim());
            return valor;
        }

        public bool existeMateria(int Id_materia)
        {
            return _bd.Materia.Any(c => c.id_materia == Id_materia);
        }

        public ICollection<Materia> getMateria()
        {
            return _bd.Materia.OrderByDescending(c=>c.nombre).ToList();
        }

        public Materia getMateria(int Id_materia)
        {
            return _bd.Materia.FirstOrDefault(c => c.id_materia == Id_materia);
        }

        public bool Guardar()
        {
            return _bd.SaveChanges()>=0?true:false;
        }
    }
}
