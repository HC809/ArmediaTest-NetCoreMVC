using ArmediaTest.BLL.DTOs;
using ArmediaTest.BLL.Services.Interfaces;
using ArmediaTest.BLL.Shared.Models;
using ArmediaTest.BLL.Utilities;
using ArmediaTest.DAL.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmediaTest.BLL.Services
{
    public class RoleService : IRoleService
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private readonly IMapper mapper;

        public RoleService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<ResponseModel> GetRoles()
        {
            var response = new ResponseModel();

            try
            {
                var data = await unitOfWork.RoleRepository.GetAsync(filter: q => q.SnActivo == true);
                var roles = mapper.Map<List<RoleDTO>>(data).ToList();

                response.IsSuccess = true;
                response.Data = roles;
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex, response);
            }

            return response;
        }
    }
}
