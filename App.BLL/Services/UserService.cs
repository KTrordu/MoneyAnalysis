using App.BLL.DTOs;
using App.BLL.IServices;
using App.DAL.IRepositories;
using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddUserAsync(UserDTO userDTO)
        {
            var user = new ApplicationUser
            {
                UserName = userDTO.UserName
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return users.Select(u => new UserDTO
            {
                UserName = u.UserName,
                Id = u.Id
            });
        }

        public async Task<UserDTO> GetUserByIdAsync(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            return new UserDTO
            {
                UserName = user.UserName,
                Id = user.Id
            };
        }

        public async Task UpdateUserAsync(UserDTO user)
        {
            var userToUpdate = new ApplicationUser
            {
                Id = user.Id,
                UserName = user.UserName
            };

            await _userRepository.UpdateAsync(userToUpdate);
            await _userRepository.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(string id)
        {
            await _userRepository.Delete(id);
            await _userRepository.SaveChangesAsync();
        } 
    }
}
