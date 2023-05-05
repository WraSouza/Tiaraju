using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiaraju.Models;

namespace Tiaraju.FirebaseServices.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> AddUser(Usuario usuario);
        Task DeleteUser(int id);
        Task<List<Usuario>> GetUsers();
        Task<Usuario> GetUser(string name);
        Task<int> GetUsersQuantity();
        Task<bool> LoginUser(string username, string password);
        Task UpdatePasswordUser(string username, string password);


    }
}
