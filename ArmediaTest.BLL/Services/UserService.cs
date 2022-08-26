using ArmediaTest.BLL.DTOs;
using ArmediaTest.BLL.Services.Interfaces;
using ArmediaTest.BLL.Shared.Models;
using ArmediaTest.BLL.Utilities;
using ArmediaTest.DAL.Entities;
using ArmediaTest.DAL.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmediaTest.BLL.Services
{
    public class UserService : IUserService
    {
        private ISPService _spService;
        private readonly IMapper mapper;

        public UserService(ISPService spService, IMapper mapper)
        {
            _spService = spService;
            this.mapper = mapper;
        }

        public ResponseModel CreateUser(UserDTO model)
        {
            var response = new ResponseModel();

            try
            {
                var user = mapper.Map<TUser>(model);
                var res = _spService.InsertUser(user);
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex, response);
            }

            return response;
        }
    }
}
