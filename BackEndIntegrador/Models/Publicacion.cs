using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndIntegrador.Models
{
    public class Publicacion
    {
        [Key]
        public int id_publicacion { get; set; }

        public DateTime fecha_publicacion { get; set; }

        public DateTime fecha_actualización { get; set; }

        public string titulo { get; set; }


        public int id_usuario { get; set; }
        [ForeignKey("id_usuario")]
        public Usuario usuario { get; set; }


    }
}
