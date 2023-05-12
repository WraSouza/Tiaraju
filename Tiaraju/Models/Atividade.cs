using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiaraju.Models
{
    public class Atividade : Modelo
    {
        public Atividade()
        {
            
        }
        public Atividade(string projectName,string activityname, string finaldate, string priority, string status, string ownerdepartment, List<string> envolved)
        {
            ProjectName = projectName;
            Name = activityname;
            FinalDate = finaldate;
            Priority = priority;
            Status = status;
            OwnerDepartment = ownerdepartment;
            EnvolvedDepartments = envolved;            
            IsFinished = false;
        }

        public string Priority { get; set; }
        public string ProjectName { get; set; }
       public string OwnerDepartment { get; set; }
        public List<string> EnvolvedDepartments { get; set; }
    }
}
