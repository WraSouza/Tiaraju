using Firebase.Database;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiaraju.FirebaseServices.Services.Interfaces;
using Tiaraju.Models;

namespace Tiaraju.FirebaseServices.Services.Implementations
{
    public class RoleServices : IRolesServices
    {
        FirebaseClient firebase;

        public RoleServices()
        {
            
        }

        public async Task<List<Role>> GetRoles()
        {
            List<Role> lista = null;
            try
            {
                lista = (await firebase.Child("Roles")
                 .OnceAsync<Role>()).Select(item => new Role
                 {
                     Id = item.Object.Id,
                     RoleName = item.Object.RoleName

                 }).ToList();


            }
            catch (FirebaseException e)
            {
                Console.WriteLine(e.ToString());
            }

            return lista;

        }
    }
}
