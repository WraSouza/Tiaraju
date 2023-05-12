using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiaraju.FirebaseServices.Services.Interfaces;
using Tiaraju.Models;

namespace Tiaraju.FirebaseServices.Services.Implementations
{
    internal class ProjectServices : IProjectServices
    {
        FirebaseClient firebase;

        public ProjectServices()
        {
            
        }

        public async Task AddProject(Project project)
        {
            await firebase.Child("Project")
                 .PostAsync(new Project()
                 {
                     Name = project.Name,
                     FinalDate = project.FinalDate,                     
                     CreatedAt = project.CreatedAt

                 });
        }

        public void DeleteProject(Project project)
        {
            throw new NotImplementedException();
        }

        public Task<Project> GetProjectByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Project>> GetProjects()
        {

            //List<Project> lista = null;            

            var lista = (await firebase.Child("Project")
             .OnceAsync<Project>()).Select(item => new Project
             {
                 Name = item.Object.Name,
                 FinalDate = item.Object.FinalDate,
                 CreatedAt = item.Object.CreatedAt,
                 IsFinished = item.Object.IsFinished
             }).ToList();

            await firebase
                .Child("Project")
                .OnceAsync<Project>();


            return lista.Where(a => a.IsFinished == false).ToList();
            
            ;
        }

        public async Task<int> GetProjectsQuantity()
        {
            return (await firebase.Child("Project")
                .OnceAsync<Project>()).Select(item => new Project
                {
                    Name = item.Object.Name,
                    FinalDate = item.Object.FinalDate,
                    CreatedAt = item.Object.CreatedAt,

                }).ToList().Count;
        }

        public Task<bool> ProjectExist(string projectName)
        {
            throw new NotImplementedException();
        }

        public void UpdateProject(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
