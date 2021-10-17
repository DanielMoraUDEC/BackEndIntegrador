using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndIntegrador.Models.Dtos
{
    public class UsuarioAuthDto
    {
        [Key]
        public int id_usuario { get; set; }

        [Required(ErrorMessage = "Nombre requerido")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Apellido requerido")]
        public string apellido { get; set; }

        [Required(ErrorMessage = "Celular requerido")]
        public string celular { get; set; }

        [Required(ErrorMessage = "Correo requerido")]
        public string correo { get; set; }

        public bool es_tutor { get; set; }

        public int rol { get; set; }

        [Required(ErrorMessage = "Contraseña requerida")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "La contraseña debe estar entre 4 y 10 caracteres")]
        public string contraseña { get; set; }

        public bool is_mail_confirmed { get; set; }

        public Guid? activation_code { get; set; }

        public int can_publicaciones { get; set; }
    }
}
