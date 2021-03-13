using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test1.Brokers;
using Test1.Models;

namespace Test1.Services
{
    public class UserService : IUserService
    {
        private readonly StorageBroker _context;
        public UserService(StorageBroker context) => _context = context;

        public async Task<User> CreateAsync(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.Where(x => true).ToArrayAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FirstAsync(x => x.Id == id);
        }
    }

    public interface IUserService
    {
        Task<User> CreateAsync(User user);
        Task<User> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
