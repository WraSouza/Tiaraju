using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiaraju.Models;

namespace Tiaraju.FirebaseServices.Services.Interfaces
{
    public interface IActivityServices
    {
        Task AddActivity(Atividade atividade);
        Task<List<Atividade>> GetActivities();
        Task<List<Atividade>> GetAtividade(string projectName);
        void FinishActivity(string name);
        Task<bool> ActivityExist(string activityName, string projectName);
        void UpdateActivity(Atividade atividade);

        

    }
}
