using ArmediaTest.BLL.DTOs;
using ArmediaTest.BLL.Services.Interfaces;
using ArmediaTest.BLL.Shared.Models;
using ArmediaTest.BLL.Utilities;
using ArmediaTest.DAL.Entities;
using ArmediaTest.DAL.Services;
using ArmediaTest.DAL.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ArmediaTest.BLL.Services
{
    public class UserService : IUserService
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private ISPService spService;
        private readonly IMapper mapper;

        public UserService(ISPService spService, IMapper mapper)
        {
            this.spService = spService;
            this.mapper = mapper;
        }

        public async Task<ResponseModel> GetUsers()
        {
            var response = new ResponseModel();

            try
            {
                var data = await unitOfWork.UserRepository.GetAsync(includeProperties: "CodRolNavigation");
                var users = mapper.Map<List<UserDTO>>(data).ToList();

                response.IsSuccess = true;
                response.Data = users;
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex, response);
            }

            return response;
        }

        public async Task<ResponseModel> GetById(int id)
        {
            var response = new ResponseModel();

            try
            {
                var data = await unitOfWork.UserRepository.GetByIdAsync(id);
                var user = mapper.Map<UserDTO>(data);

                response.IsSuccess = true;
                response.Data = user;
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex, response);
            }

            return response;
        }

        public async Task<ResponseModel> CreateUser(UserDTO model)
        {
            var response = new ResponseModel();

            try
            {
                var user = mapper.Map<TUser>(model);
                var spResponse = await spService.InsertUser(user);

                var dataResponse = mapper.Map<ResponseModel>(spResponse);
                model.CodUsuario = dataResponse.Data;
                response.Data = model;

                response.IsSuccess = dataResponse.IsSuccess;
                response.Message = dataResponse.Message;
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex, response);
            }

            return response;
        }

        public async Task<ResponseModel> UpdateUser(UserDTO model)
        {
            var response = new ResponseModel();

            try
            {
                var existUserWithSameUserName = (await unitOfWork.UserRepository.GetAsync(filter: q => q.TxtUser == model.TxtUser && q.CodUsuario != model.CodUsuario)).FirstOrDefault();
                if (existUserWithSameUserName != null)
                {
                    response.Message = $"Ya existe un usuario creado con el nombre de usuario: {model.TxtUser}";
                    return response;
                }
                var existUserWithSameDoc = (await unitOfWork.UserRepository.GetAsync(filter: q => q.NroDoc == model.NroDoc && q.CodUsuario != model.CodUsuario)).FirstOrDefault();
                if (existUserWithSameDoc != null)
                {
                    response.Message = $"Ya existe un usuario creado con el número de documento: {model.NroDoc}";
                    return response;
                }

                model.TxtPassword = "armedia";

                var userToDb = mapper.Map<TUser>(model);
                unitOfWork.UserRepository.Update(userToDb);
                await unitOfWork.SaveAsync();

                response.IsSuccess = true;
                response.Data = mapper.Map<UserDTO>(userToDb);
                response.Message = "Usuario actualizado exitosamente!";
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex, response);
            }

            return response;
        }

        public async Task<ResponseModel> DeleteUser(int id)
        {
            var response = new ResponseModel();

            try
            {
                var user = await unitOfWork.UserRepository.GetByIdAsync(id);

                if (user == null)
                {
                    response.Message = $"El usuario con código {id} no existe.";
                    return response;
                }

                await unitOfWork.UserRepository.DeleteAsync(id);
                await unitOfWork.SaveAsync();

                response.IsSuccess = true;
                response.Data = id;
                response.Message = "Usuario eliminado exitosamente!";
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex, response);
            }

            return response;
        }
    }
}
