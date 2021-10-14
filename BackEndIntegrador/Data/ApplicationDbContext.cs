using BackEndIntegrador.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndIntegrador.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Materia> Materia { get; set; }
        public DbSet<Publicacion> Publicacion { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Tema> Tema { get; set; }
        public DbSet<UsuarioMateria> UsuarioMateria { get; set; }

    }
}
