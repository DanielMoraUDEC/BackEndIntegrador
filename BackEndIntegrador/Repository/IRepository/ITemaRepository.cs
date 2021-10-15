using BackEndIntegrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndIntegrador.Repository.IRepository
{
    public interface ITemaRepository
    {
        ICollection<Tema> GetTema();
        Tema GetTema(int id_tema);
        bool ExisteTema(int id_tema);
        bool CrearTema(Tema tema);
        bool ActualizarTema(Tema tema);
        bool BorrarTema(Tema tema);
        bool Guardar();
    }
}
