using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndIntegrador.Models.Dtos
{
    public class UsuarioDto
    {
        public string nombre { get; set; }

        public string apellido { get; set; }

        public string celular { get; set; }

        public string correo { get; set; }

        public bool es_tutor { get; set; }

        public int rol { get; set; }

        public byte[] pass_hash { get; set; }

        public bool is_mail_confirmed { get; set; }

        public string activation_code { get; set; }

        public int can_publicaciones { get; set; }
    }
}
