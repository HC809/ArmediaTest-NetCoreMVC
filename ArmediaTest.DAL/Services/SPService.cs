using ArmediaTest.DAL.Entities;
using ArmediaTest.DAL.Models;
using ArmediaTest.DAL.Services.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmediaTest.DAL.Services
{
    public class SPService : ISPService
    {
        protected string connString = "Server=myserver809.database.windows.net;database=TestCrud;user=admin809;password=azure@2022*;";

        public async Task<StoreProcedureResponse> InsertUser(TUser model)
        {
            StoreProcedureResponse response = new StoreProcedureResponse();

            try
            {
                using (var db = new SqlConnection(connString))
                {
                    var paramsList = new DynamicParameters();
                    paramsList.Add("usuario", model.TxtUser);
                    paramsList.Add("usuario", model.TxtUser);
                    paramsList.Add("usuario", model.TxtUser);
                    paramsList.Add("usuario", model.TxtUser);
                    paramsList.Add("usuario", model.TxtUser);
                    paramsList.Add("usuario", model.TxtUser);

                    var result = await db.ExecuteAsync("spInsertUser");
                }
            }
            catch (Exception)
            {

                throw;
            }

            return response;
        }
    }
}
