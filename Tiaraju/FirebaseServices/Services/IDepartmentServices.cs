using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiaraju.Models;

namespace Tiaraju.FirebaseServices.Services
{
    public interface IDepartmentServices
    {
        Task<List<Department>> GetDepartments();
    }
}
