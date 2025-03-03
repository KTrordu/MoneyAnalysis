using App.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace App.UI.ViewModels.Role
{
    public class RoleEditViewModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<ApplicationUser> Members { get; set; }
        public IEnumerable<ApplicationUser> NonMembers { get; set; }
    }
}
