using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tiaraju.FirebaseServices.Services.Interfaces;
using Tiaraju.Models;

namespace Tiaraju.FirebaseServices.Services.Implementations
{
    public class ActivityServices : IActivityServices
    {
        FirebaseClient firebase;

        public ActivityServices()
        {
            firebase = new FirebaseClient("https://laboratoriotiaraju-6c89e-default-rtdb.firebaseio.com/");
        }

        public async Task AddActivity(Atividade atividade)
        {   
            await firebase.Child("Atividades")
                 .PostAsync(new Atividade()
                 {
                     ProjectName = atividade.ProjectName,
                     Name = atividade.Name,
                     FinalDate = atividade.FinalDate,
                     Priority = atividade.Priority,
                     Status = atividade.Status,
                     OwnerDepartment = atividade.OwnerDepartment,
                     EnvolvedDepartments = atividade.EnvolvedDepartments

                 });
        }

        public void FinishActivity(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Atividade>> GetAtividade(string atividadeName)
        {
            var listaBanco = await GetActivities();

            await firebase
                .Child("Atividades")
                .OnceAsync<Atividade>();

            return listaBanco.Where(a => a.Name == atividadeName).ToList();
        }

        public async Task<List<Atividade>> GetActivities()
        {
            return (await firebase.Child("Atividades")
                .OnceAsync<Atividade>()).Select(item => new Atividade
                {
                    ProjectName = item.Object.ProjectName,
                    Name = item.Object.Name,
                    FinalDate = item.Object.FinalDate,
                    Priority = item.Object.Priority,
                    Status = item.Object.Status,
                    OwnerDepartment = item.Object.OwnerDepartment,
                    EnvolvedDepartments = item.Object.EnvolvedDepartments
                }).ToList();
        }

        public async Task<bool> ActivityExist(string activityName, string projectName)
        {
            var user = (await firebase.Child("Atividades")
                .OnceAsync<Atividade>())
                .Where(u => u.Object.Name == activityName)
                .Where(u => u.Object.ProjectName == projectName)
                .FirstOrDefault();

            return (user != null);
        }

        public async void UpdateActivity(Atividade atividade)
        {
            var activities = await GetActivities();

            var atualizarAtividade = (await firebase
            .Child("Atividades")
              .OnceAsync<Atividade>()).Where(a => a.Object.ProjectName == atividade.ProjectName && a.Object.Name == atividade.Name).FirstOrDefault();

            atualizarAtividade.Object.ProjectName = atividade.ProjectName;
            atualizarAtividade.Object.Name = atividade.Name;
            atualizarAtividade.Object.Status = atividade.Status;
            atualizarAtividade.Object.Priority = atividade.Priority;
            atualizarAtividade.Object.OwnerDepartment = atividade.OwnerDepartment;
            atualizarAtividade.Object.EnvolvedDepartments = atividade.EnvolvedDepartments;

            await firebase
           .Child("Atividades")
           .Child(atualizarAtividade.Key)
           .PutAsync(atualizarAtividade.Object);

            //return true;
        }
    }
}
