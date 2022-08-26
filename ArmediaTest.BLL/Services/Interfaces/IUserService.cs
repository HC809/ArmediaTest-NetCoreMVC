using ArmediaTest.BLL.DTOs;
using ArmediaTest.BLL.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmediaTest.BLL.Services.Interfaces
{
    public interface IUserService
    {
        ResponseModel CreateUser(UserDTO model);
    }
}
