using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndIntegrador.Models.Dtos
{
    public class UsuarioMateriaDto
    {
        [Key]
        public int id_usuario_materia { get; set; }

        public double calificacon { get; set; }

        public byte[] content_file { get; set; }

        public string file_name { get; set; }

        public string file_type { get; set; }


        public int id_materia { get; set; }
        [ForeignKey("id_materia")]
        public Materia materia { get; set; }

        public int id_usuario { get; set; }
        [ForeignKey("id_usuario")]
        public Usuario usuario { get; set; }
    }
}
