using BlazorApp.Client.Helpers;
using BlazorApp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Client.Services
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IHttpService _httpService;
        private string url = "api/department";

        public DepartmentRepository(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task CreateDepartment(Department department)
        {
            var response = await _httpService.Post(url, department);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task UpdateDepartment(Department department)
        {
            var response = await _httpService.Put(url, department);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task<List<Department>> GetDepartments()
        {
            var response = await _httpService.Get<List<Department>>(url);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public async Task<Department> GetDepartment(int id)
        {
            var response = await _httpService.Get<Department>($"{url}/{id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public async Task DeleteDepartment(int id)
        {
            var response = await _httpService.Delete($"{url}/{id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
