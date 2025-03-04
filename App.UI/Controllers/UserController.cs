using App.BLL.DTOs;
using App.BLL.IServices;
using App.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;

        public UserController(UserManager<ApplicationUser> userManager, IUserService userService)
        {
            _userManager = userManager;
            _userService = userService;
        }

        //READ: List all users
        public IActionResult Index()
        {
            return View(_userManager.Users);
        }

        //UPDATE: GET
        public async Task<IActionResult> Update(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            return View(user);
        }

        //UPDATE: POST
        [HttpPost]
        public async Task<IActionResult> Update(ApplicationUser applicationUser)
        {
            var userToUpdate = await _userManager.FindByIdAsync(applicationUser.Id);
            if (userToUpdate == null) return NotFound();

            userToUpdate.UserName = applicationUser.UserName;
            await _userService.UpdateUserAsync(new UserDTO
            {
                Id = userToUpdate.Id,
                UserName = userToUpdate.UserName
            });

            return RedirectToAction("Index");
        }
    }
}
