using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmediaTest.BLL.DTOs
{
    public class RoleDTO
    {
        public int CodRol { get; set; }
        public string TxtDesc { get; set; } = null!;
        public bool? SnActivo { get; set; }
    }
}
