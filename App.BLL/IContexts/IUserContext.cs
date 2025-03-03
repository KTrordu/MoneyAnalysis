using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.IContexts
{
    public interface IUserContext
    {
        string UserId { get; }
        IEnumerable<string> Roles { get; }
    }
}
