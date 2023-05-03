using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiaraju.Models;

namespace Tiaraju.FirebaseServices.Services
{
    internal class ProjectServices : IProjectServices
    {
        FirebaseClient firebase;

        public ProjectServices()
        {
            firebase = new FirebaseClient("https://laboratoriotiaraju-6c89e-default-rtdb.firebaseio.com/");
        }

        public async Task AddProject(Project project)
        {
            await firebase.Child("Project")
                 .PostAsync(new Project()
                 {
                    Id = project.Id,
                    ProjectName = project.ProjectName,
                    FinalDate = project.FinalDate,
                    Departments = project.Departments,
                    Priority = project.Priority,
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
            List<Project> lista = null;
            try
            {
                lista = (await firebase.Child("Project")
                 .OnceAsync<Project>()).Select(item => new Project
                 {
                     Id = item.Object.Id,
                     ProjectName = item.Object.ProjectName,
                     FinalDate = item.Object.FinalDate,
                     Departments = item.Object.Departments,
                     Priority = item.Object.Priority,
                     CreatedAt = item.Object.CreatedAt,
                    

                 }).ToList();


            }
            catch (FirebaseException e)
            {
                Console.WriteLine(e.ToString());
            }

            return lista;
        }

        public async Task<int> GetProjectsQuantity()
        {
            return (await firebase.Child("Project")
                .OnceAsync<Project>()).Select(item => new Project
                {
                    Id = item.Object.Id,
                    ProjectName = item.Object.ProjectName,
                    FinalDate = item.Object.FinalDate,
                    Priority = item.Object.Priority,
                    CreatedAt = item.Object.CreatedAt,
                    Departments = item.Object.Departments,
                }).ToList().Count;
        }

        public void UpdateProject(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
