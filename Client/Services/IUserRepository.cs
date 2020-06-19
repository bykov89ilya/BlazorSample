using BlazorApp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Client.Services
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
    }
}
