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
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartmentController(
            AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Department>>> Get()
        {
            return await _context.Departments.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> Get(int id)
        {
            return await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<int> Post(Department department)
        {
            _context.Add(department);
            await _context.SaveChangesAsync();
            return department.Id;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Department department)
        {
            _context.Attach(department).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(d => d.Id == id);
            if (department == null)
            {
                return NotFound(); 
            }
            _context.Remove(department);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}