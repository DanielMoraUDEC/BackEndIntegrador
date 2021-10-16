using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndIntegrador.Models.Dtos
{
    public class TemaDto
    {
        public int id_tema { get; set; }

        public string contenido { get; set; }

        public byte[] content_file { get; set; }

        public string file_name { get; set; }

        public string file_type { get; set; }


        public int id_publicacion { get; set; }
        [ForeignKey("id_publicacion")]
        public Publicacion publicacion { get; set; }
    }
}
