using ArmediaTest.BLL.DTOs;
using ArmediaTest.BLL.Services.Interfaces;
using ArmediaTest.BLL.Shared.Models;
using ArmediaTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ArmediaTest.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index() => View();

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