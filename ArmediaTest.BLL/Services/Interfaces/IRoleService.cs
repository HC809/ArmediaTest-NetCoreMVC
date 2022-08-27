using ArmediaTest.BLL.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmediaTest.BLL.Services.Interfaces
{
    public interface IRoleService
    {
        Task<ResponseModel> GetRoles();
    }
}
