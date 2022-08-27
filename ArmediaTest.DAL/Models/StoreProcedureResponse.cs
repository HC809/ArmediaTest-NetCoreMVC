using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmediaTest.DAL.Models
{
    public class StoreProcedureResponse
    {
        public bool IsSuccess { get; set; } = false;
        public string? Message { get; set; }
        public dynamic? Data { get; set; }
    }
}
