using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndIntegrador.Models.Dtos
{
    public class MateriaDto
    {
        [Key]
        public int id_materia { get; set; }

        public string nombre { get; set; }


    }
}
