using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test1.Models;
using Test1.Services;

namespace Test1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
            => _userService = userService;

        [HttpPost]
        public async Task<User> CreateAsync([FromBody] User user)
        {
            return await _userService.CreateAsync(user);
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userService.GetAllAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<User> GetByIdAsync(int id)
        {
            return await _userService.GetByIdAsync(id);
        }
    }
}
