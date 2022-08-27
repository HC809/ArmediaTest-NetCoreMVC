using ArmediaTest.BLL.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmediaTest.BLL.Utilities
{
    public static class ErrorHandler
    {
        public static void HandleError(Exception ex, ResponseModel response)
        {
            response.IsSuccess = false;

            if (ex?.InnerException?.Message != null && ex?.InnerException?.Message != String.Empty)
            {
                response.Message = ex?.InnerException?.Message ?? "Error no definido.";
            }
            else if (ex?.Message != null && ex?.Message != String.Empty)
            {
                response.Message = ex?.Message ?? "Error no definido.";
            }
        }
    }
}
