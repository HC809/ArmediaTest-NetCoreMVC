using ArmediaTest.DAL.Entities;
using ArmediaTest.DAL.Models;
using ArmediaTest.DAL.Services.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmediaTest.DAL.Services
{
    public class SPService : ISPService
    {
        protected string connString = "Server=myserver809.database.windows.net;database=TestCrud;user=admin809;password=azure@2022*;";

        /// <summary>
        /// STORE PROCEDUDE FOR INSERT USER
        /// *VALIDATE IF USERNAME OR DOCUMENT NUMBER EXIST*
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<StoreProcedureResponse> InsertUser(TUser model)
        {
            StoreProcedureResponse response = new StoreProcedureResponse();

            try
            {
                using (var db = new SqlConnection(connString))
                {
                    var _params = new DynamicParameters();
                    _params.Add("usuario", model.TxtUser);
                    _params.Add("password", "armedia");
                    _params.Add("nombre", model.TxtNombre);
                    _params.Add("apellido", model.TxtApellido);
                    _params.Add("documento", model.NroDoc);
                    _params.Add("codigoRol", model.CodRol);
                    _params.Add("isSuccess", false, dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    _params.Add("id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                    _params.Add("msg", string.Empty, dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                    await db.ExecuteAsync(sql: "spInsertUser", param: _params, commandType: CommandType.StoredProcedure);

                    response.IsSuccess = _params.Get<bool>("isSuccess");
                    response.Data = _params.Get<int>("id");
                    response.Message = _params.Get<string?>("msg");
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
