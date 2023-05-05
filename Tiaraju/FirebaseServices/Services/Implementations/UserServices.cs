using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tiaraju.FirebaseServices.Services.Interfaces;
using Tiaraju.Models;

namespace Tiaraju.FirebaseServices.Services.Implementations
{
    public class UserServices : IUserService
    {
        FirebaseClient firebase;

        public UserServices()
        {
            firebase = new FirebaseClient("https://laboratoriotiaraju-6c89e-default-rtdb.firebaseio.com/");
        }

        public async Task<bool> AddUser(Usuario usuario)
        {
            await firebase.Child("Usuario")
                .PostAsync(new Usuario()
                {
                    Id = usuario.Id,
                    Name = usuario.Name,
                    UserName = usuario.UserName,
                    IsActive = usuario.IsActive,
                    Password = usuario.Password,
                    Department = usuario.Department,
                    Role = usuario.Role
                });

            return true;
        }

        public Task DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> GetUser(string name)
        {
            var users = await GetUsers();

            await firebase
               .Child("Usuario")
               .OnceAsync<Usuario>();

            var selectedUser = users.Where(x => x.UserName == name).FirstOrDefault();

            return selectedUser;
        }

        public async Task<List<Usuario>> GetUsers()
        {
            return (await firebase.Child("Usuario")
                .OnceAsync<Usuario>()).Select(item => new Usuario
                {
                    Id = item.Object.Id,
                    Name = item.Object.Name,
                    UserName = item.Object.UserName,
                    IsActive = item.Object.IsActive,
                    Password = item.Object.Password,
                    Department = item.Object.Department,

                }).ToList();
        }

        public async Task<int> GetUsersQuantity()
        {
            return (await firebase.Child("Usuario")
                .OnceAsync<Usuario>()).Select(item => new Usuario
                {
                    Id = item.Object.Id,
                    Name = item.Object.Name,
                    UserName = item.Object.UserName,
                    Department = item.Object.Department,
                    Password = item.Object.Password,
                    IsActive = item.Object.IsActive
                }).ToList().Count;
        }

        public async Task<bool> LoginUser(string username, string password)
        {
            var user = (await firebase.Child("Usuario")
               .OnceAsync<Usuario>())
               .Where(u => u.Object.UserName == username)
               .Where(u => u.Object.Password == password)
               .FirstOrDefault();


            return user != null;
        }

        public async Task UpdatePasswordUser(string username, string password)
        {
            var usuarios = await GetUsers();

            var toUpdatePerson = (await firebase
              .Child("Usuario")
              .OnceAsync<Usuario>()).Where(a => a.Object.UserName == username).FirstOrDefault();

            toUpdatePerson.Object.Password = password;

            await firebase
           .Child("Usuario")
           .Child(toUpdatePerson.Key)
           .PutAsync(toUpdatePerson.Object);

        }
    }
}
