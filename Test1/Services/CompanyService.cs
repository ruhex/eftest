using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test1.Brokers;
using Test1.Models;

namespace Test1.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly StorageBroker _context;
        public CompanyService(StorageBroker context) => _context = context;

        public async Task<Company> CreateAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
            await _context.Users.AddRangeAsync(Test1(company));
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _context.Companies.Where(x => true).ToArrayAsync();
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await _context.Companies
                .Include(u => u.Users)
                .FirstAsync(x => x.Id == id);
        }

        private List<User> Test1(Company company)
        {
            List<User> newUser = new List<User>();

            foreach(User tmpUser in company.Users)
            {
                tmpUser.CompanyId = company.Id;
                newUser.Add(tmpUser);
            }
            return newUser;
        }

        
    }

    public interface ICompanyService
    {
        Task<Company> CreateAsync(Company company);
        Task<Company> GetByIdAsync(int id);
        Task<IEnumerable<Company>> GetAllAsync();
    }
}
