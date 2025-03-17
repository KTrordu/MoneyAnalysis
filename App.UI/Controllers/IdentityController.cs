using App.BLL.IContexts;
using App.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.UI.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IUserContext _userContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityController(IUserContext userContext, UserManager<ApplicationUser> userManager)
        {
            _userContext = userContext;
            _userManager = userManager;
        }

        public async Task<IActionResult> AccessDenied()
        {
            var userId = _userContext.UserId;
            var user = await _userManager.FindByIdAsync(userId);
            return await Task.FromResult(View(user));
        }
    }
}
