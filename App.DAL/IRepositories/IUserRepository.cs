using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.IRepositories
{
    public interface IUserRepository
    {
        Task AddAsync(ApplicationUser user);
        Task<IEnumerable<ApplicationUser>> GetAllAsync();
        Task<ApplicationUser> GetByIdAsync(string id);
        Task UpdateAsync(ApplicationUser user);
        Task Delete(string id);
        Task SaveChangesAsync();
    }
}
