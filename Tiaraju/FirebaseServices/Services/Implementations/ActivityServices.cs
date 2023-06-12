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
                     Status = atividade.Status,
                     OwnerDepartment = atividade.OwnerDepartment,
                     EnvolvedDepartments = atividade.EnvolvedDepartments,
                     Urgencia = atividade.Urgencia,
                     Importancia = atividade.Importancia

                 });
        }

        public async void FinishActivity(string activityname, string projectname)
        {
            bool finished = true;

            string atividadeConcluida = "Concluído";

            var activities = await GetActivities();

            var encerrarAtividade = (await firebase
            .Child("Atividades")
              .OnceAsync<Atividade>()).Where(a => a.Object.ProjectName == projectname && a.Object.Name == activityname).FirstOrDefault();

            encerrarAtividade.Object.IsFinished = finished;
            encerrarAtividade.Object.Status = atividadeConcluida;            

            await firebase
           .Child("Atividades")
           .Child(encerrarAtividade.Key)
           .PutAsync(encerrarAtividade.Object);

        }

        public async Task<List<Atividade>> GetAtividade(string projectName)
        {
            var listaBanco = await GetActivities();

            await firebase
                .Child("Atividades")
                .OnceAsync<Atividade>();

            return listaBanco.Where(a => a.ProjectName == projectName).ToList();
        }

        public async Task<List<Atividade>> GetActivities()
        {
            return (await firebase.Child("Atividades")
                .OnceAsync<Atividade>()).Select(item => new Atividade
                {
                    ProjectName = item.Object.ProjectName,
                    Name = item.Object.Name,
                    FinalDate = item.Object.FinalDate,                    
                    Status = item.Object.Status,
                    OwnerDepartment = item.Object.OwnerDepartment,
                    EnvolvedDepartments = item.Object.EnvolvedDepartments,
                    IsFinished = item.Object.IsFinished,
                    Importancia = item.Object.Importancia,
                    Urgencia = item.Object.Urgencia
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
            atualizarAtividade.Object.FinalDate = atividade.FinalDate;
            atualizarAtividade.Object.OwnerDepartment = atividade.OwnerDepartment;
            atualizarAtividade.Object.EnvolvedDepartments = atividade.EnvolvedDepartments;
            atualizarAtividade.Object.Urgencia = atividade.Urgencia;
            atualizarAtividade.Object.Importancia = atividade.Importancia;

            await firebase
           .Child("Atividades")
           .Child(atualizarAtividade.Key)
           .PutAsync(atualizarAtividade.Object);
            
        }

        public async Task<Atividade> GetActivityByName(string activityName, string projectName)
        {
            var listaBanco = await GetActivities();

            await firebase
                .Child("Atividades")
                .OnceAsync<Atividade>();

            return listaBanco.Where(a => a.Name == activityName && a.ProjectName == projectName).FirstOrDefault();
        }

        public async void DeleteActivity(string activityName, string projectName)
        {            
                var activities = await GetActivities();
               
                var toDeleteActivity = (await firebase
                  .Child("Atividades")
                  .OnceAsync<Atividade>()).Where(a => (a.Object.Name == activityName || a.Object.ProjectName == projectName)).FirstOrDefault();

                if (toDeleteActivity != null)
                {
                    await firebase
                        .Child("Atividades")
                        .Child(toDeleteActivity.Key)
                        .DeleteAsync();
                }            
        }

        public async Task<List<Atividade>> GetActivityByDepartment(string department)
        {
            var listaBanco = await GetActivities();

            await firebase
                .Child("Atividades")
                .OnceAsync<Atividade>();

            return listaBanco.Where(a => a.OwnerDepartment == department).ToList();
        }

        public async Task<int> ReturnActivityQuantity(string projectName)
        {
            var listaBanco = await GetActivities();

            await firebase
                .Child("Atividades")
                .OnceAsync<Atividade>();

            return listaBanco.Where(a => a.ProjectName == projectName).ToList().Count();
        }

        public async void ChangeStatusToLate()
        {
            var activities = await GetActivities();

            var atualizarAtividade = (await firebase
            .Child("Atividades")
              .OnceAsync<Atividade>()).Where(a => DateTime.Parse(a.Object.FinalDate) < DateTime.Today && a.Object.IsFinished == false).ToList();

            if(atualizarAtividade.Count > 0)
            {
                foreach (var item in atualizarAtividade)
                {
                    item.Object.Status = "Em Atraso";

                    await firebase
                         .Child("Atividades")
                         .Child(item.Key)
                         .PutAsync(item.Object);
                }
            }           
                       
        }
    }
}
