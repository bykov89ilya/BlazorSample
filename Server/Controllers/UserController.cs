using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Server.Services;
using BlazorApp.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(
            AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            var users = _context.Users
                .Include(p => p.Department)
                .AsEnumerable();
            return users;
        }

        [HttpPost]
        public async Task<int> Post(User user)
        {
            user.Department = _context.Departments.Find(user.DepId);
            _context.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }
    }
}