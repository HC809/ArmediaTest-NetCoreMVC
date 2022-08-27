using ArmediaTest.BLL.DTOs;
using ArmediaTest.BLL.Shared.Models;
using ArmediaTest.DAL.Entities;
using ArmediaTest.DAL.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmediaTest.BLL.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TRol, RoleDTO>().ReverseMap();
            CreateMap<TUser, UserDTO>()
                .ForMember(dest => dest.TxtNombre, opt => opt.MapFrom(src => $"{src.TxtNombre} {src.TxtApellido}"))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.CodRolNavigation.TxtDesc));
            CreateMap<UserDTO, TUser>();
            CreateMap<StoreProcedureResponse, ResponseModel>().ReverseMap();
        }
    }
}
