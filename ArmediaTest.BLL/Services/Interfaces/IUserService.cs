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
        Task<ResponseModel> GetUsers();
        Task<ResponseModel> GetById(int id);
        Task<ResponseModel> CreateUser(UserDTO model);
        Task<ResponseModel> UpdateUser(UserDTO model);
        Task<ResponseModel> DeleteUser(int id);
    }
}
