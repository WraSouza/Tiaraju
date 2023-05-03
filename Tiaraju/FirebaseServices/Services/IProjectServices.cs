using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiaraju.Models;

namespace Tiaraju.FirebaseServices.Services
{
    internal interface IProjectServices
    {
        Task<List<Project>> GetProjects();
        Task<Project> GetProjectByName(string name);
        void DeleteProject(Project project);
        void UpdateProject(Project project);
        Task AddProject(Project project);
        Task<int> GetProjectsQuantity();
    }
}
