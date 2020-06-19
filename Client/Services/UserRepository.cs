using BlazorApp.Client.Helpers;
using BlazorApp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Client.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly IHttpService _httpService;
        private string url = "api/user";

        public UserRepository(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task CreateUser(User user)
        {
            var response = await _httpService.Post(url, user);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
