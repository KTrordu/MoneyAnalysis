using App.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.IServices
{
    public interface IUserService
    {
        Task AddUserAsync(UserDTO user);
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(string id);
        Task UpdateUserAsync(UserDTO user);
        Task DeleteUserAsync(string id);
    }
}
