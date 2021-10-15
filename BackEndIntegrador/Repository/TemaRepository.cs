using BackEndIntegrador.Data;
using BackEndIntegrador.Models;
using BackEndIntegrador.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndIntegrador.Repository
{
    public class TemaRepository : ITemaRepository
    {
        private readonly ApplicationDbContext _bd;

        public TemaRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public bool ActualizarTema(Tema tema)
        {
            _bd.Tema.Update(tema);
            return Guardar();
        }

        public bool BorrarTema(Tema tema)
        {
            _bd.Tema.Remove(tema);
            return Guardar();
        }

        public bool CrearTema(Tema tema)
        {
            _bd.Tema.Add(tema);
            return Guardar();
        }

        public bool ExisteTema(int id_tema)
        {
            bool valor = _bd.Tema.Any(t => t.id_tema == id_tema);
            return valor;
        }

        public ICollection<Tema> GetTema()
        {
            return _bd.Tema.OrderBy(t => t.id_tema).ToList();
        }

        public Tema GetTema(int id_tema)
        {
            return _bd.Tema.FirstOrDefault(t => t.id_tema == id_tema);
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
