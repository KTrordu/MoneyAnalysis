using App.DAL.IRepositories;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(ApplicationUser user)
        {
            await _db.Users.AddAsync(user);
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<ApplicationUser> GetByIdAsync(string id)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateAsync(ApplicationUser user)
        {
            var userToUpdate = await _db.Users.FirstOrDefaultAsync(u => u.Id == user.Id);

            userToUpdate.UserName = user.UserName;
            _db.Users.Update(userToUpdate);

            await _db.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var userToDelete = await _db.Users.FirstOrDefaultAsync(u => u.Id == id);

            _db.Users.Remove(userToDelete);

            await _db.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
