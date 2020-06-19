using BlazorApp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Client.Services
{
    interface IDepartmentRepository
    {
        Task CreateDepartment(Department department);
        Task<Department> GetDepartment(int id);
        Task<List<Department>> GetDepartments();
        Task UpdateDepartment(Department department);
        Task DeleteDepartment(int id);
    }
}
