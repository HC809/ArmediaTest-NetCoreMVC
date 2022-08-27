using ArmediaTest.DAL.Entities;
using ArmediaTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmediaTest.DAL.Services.Interfaces
{
    public interface ISPService
    {
        Task<StoreProcedureResponse> InsertUser(TUser model);
    }
}
