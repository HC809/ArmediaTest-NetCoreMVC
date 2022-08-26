using ArmediaTest.BLL.DTOs;
using ArmediaTest.BLL.Services.Interfaces;
using ArmediaTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ArmediaTest.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userService;

        public HomeController(IUserService userService )
        {
            _userService = userService;
        }
        
        public IActionResult Index()
        {
            var dto = new UserDTO() {
                TxtUser = "samira24",
                TxtPassword = "123",
                TxtNombre = "Samira",
                TxtApellido = "Urbina",
                NroDoc = "434343434",
                CodRol = 1,
                SnActivo = true
            }; 
            var res = _userService.CreateUser(dto);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}