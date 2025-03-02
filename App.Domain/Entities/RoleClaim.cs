using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class RoleClaim : BaseEntity
    {
        public int? RoleId { get; set; }
        public Role Role { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
