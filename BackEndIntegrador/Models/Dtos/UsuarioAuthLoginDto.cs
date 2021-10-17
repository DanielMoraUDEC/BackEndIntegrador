using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndIntegrador.Models.Dtos
{
    public class UsuarioAuthLoginDto
    {
        [Required(ErrorMessage = "Correo requerido")]
        public string correo { get; set; }

        [Required(ErrorMessage = "Contraseña requerida")]
        public string contraseña { get; set; }
    }
}
