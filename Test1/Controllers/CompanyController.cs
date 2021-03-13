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
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
            => _companyService = companyService;

        [HttpPost]
        public async Task<Company> CreateAsync([FromBody] Company company)
        {
            return await _companyService.CreateAsync(company);
        }

        [HttpGet]
        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _companyService.GetAllAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<Company> GetByIdAsync(int id)
        {
            return await _companyService.GetByIdAsync(id);
        }
    }
}
