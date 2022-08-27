using ArmediaTest.BLL.DTOs;
using ArmediaTest.BLL.Services.Interfaces;
using ArmediaTest.BLL.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArmediaTest.Controllers
{
    public class UsersController : Controller
    {
        private IUserService _userService;
        private IRoleService _roleService;

        public UsersController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public IActionResult Index() => View();

        public async Task<IActionResult> FormView(int userCode)
        {
            var roles = await _roleService.GetRoles();
            var roleList = (roles.Data as List<RoleDTO>);
            ViewBag.Roles = roleList != null ? roleList.Select(x => new SelectListItem { Value = x.CodRol.ToString(), Text = x.TxtDesc }) : new List<SelectListItem>();

            return PartialView("_Form", userCode != 0 ? (await _userService.GetById(userCode)).Data : new UserDTO() { SnActivo = true });
        }

        public async Task<IActionResult> GetAll() => Ok(await _userService.GetUsers());

        public async Task<IActionResult> Save(UserDTO model) => Ok(model.CodUsuario == 0 ? await _userService.CreateUser(model) : await _userService.UpdateUser(model));

        public async Task<IActionResult> Delete(int id) => Ok(await _userService.DeleteUser(id));
    }
}
