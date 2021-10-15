using BackEndIntegrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndIntegrador.Repository.IRepository
{
    public interface IMateriaRepository
    {
        ICollection<Materia> getMateria();

        Materia getMateria(int Id_materia);

        bool existeMateria(string Materia);

        bool existeMateria(int Id_materia);

        bool crearMateria(Materia materia);

        bool actualizarMateria(Materia materia);

        bool borrarMateria(Materia materia);

        bool Guardar();
    }
}
