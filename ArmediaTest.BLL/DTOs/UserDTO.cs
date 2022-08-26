using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmediaTest.BLL.DTOs
{
    public class UserDTO
    {
        public int CodUsuario { get; set; }
        public string TxtUser { get; set; } = null!;
        public string TxtPassword { get; set; } = null!;
        public string TxtNombre { get; set; } = null!;
        public string TxtApellido { get; set; } = null!;
        public string NroDoc { get; set; } = null!;
        public int CodRol { get; set; }
        public bool? SnActivo { get; set; }
    }
}
