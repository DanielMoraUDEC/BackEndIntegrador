using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndIntegrador.Models
{
    public class Usuario
    {
        [Key]
        public int id_usuario { get; set; }


        public string nombre { get; set; }

        public string apellido { get; set; }

        public int celular { get; set; }

        public string correo { get; set; }

        public bool es_tutor { get; set; }

        public int rol { get; set; }

        public string contraseña { get; set; }

        public int salt { get; set; }

        public bool is_mail_confirmed { get; set; }

        public string activation_code { get; set; }

        public int can_publicaciones { get; set; }
    }
}
