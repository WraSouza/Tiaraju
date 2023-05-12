using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiaraju.FirebaseServices.Services.Interfaces;
using Tiaraju.Models;

namespace Tiaraju.FirebaseServices.Services.Implementations
{
    public class DepartmentServices : IDepartmentServices
    {
        FirebaseClient firebase;

        public DepartmentServices()
        {
            
        }

        public async Task<List<Department>> GetDepartments()
        {
            List<Department> lista = null;
            try
            {
                lista = (await firebase.Child("Department")
                 .OnceAsync<Department>()).Select(item => new Department
                 {
                     Id = item.Object.Id,
                     DepartmentName = item.Object.DepartmentName,
                     DepartmentAcronym = item.Object.DepartmentAcronym,

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
