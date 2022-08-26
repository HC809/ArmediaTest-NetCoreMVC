using System;
using System.Collections.Generic;

namespace ArmediaTest.DAL.Entities
{
    public partial class TUser
    {
        public int CodUsuario { get; set; }
        public string TxtUser { get; set; } = null!;
        public string TxtPassword { get; set; } = null!;
        public string TxtNombre { get; set; } = null!;
        public string TxtApellido { get; set; } = null!;
        public string NroDoc { get; set; } = null!;
        public int CodRol { get; set; }
        public int SnActivo { get; set; }

        public virtual TRol CodRolNavigation { get; set; } = null!;
    }
}
