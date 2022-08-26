using System;
using System.Collections.Generic;

namespace ArmediaTest.DAL.Entities
{
    public partial class TRol
    {
        public TRol()
        {
            TUsers = new HashSet<TUser>();
        }

        public int CodRol { get; set; }
        public string TxtDesc { get; set; } = null!;
        public int SnActivo { get; set; }

        public virtual ICollection<TUser> TUsers { get; set; }
    }
}
