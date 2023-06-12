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
        public Atividade(string projectName
            ,string activityname
            ,string finaldate            
            , string status
            , string ownerdepartment
            , List<string> envolved, int urgencia, int importancia)
        {
            ProjectName = projectName;
            Name = activityname;
            FinalDate = finaldate;           
            Status = status;
            OwnerDepartment = ownerdepartment;
            EnvolvedDepartments = envolved;            
            IsFinished = false;
            Urgencia = urgencia;
            Importancia = importancia;
        }
        
        public string ProjectName { get; set; }
        public string OwnerDepartment { get; set; }
        public List<string> EnvolvedDepartments { get; set; }
        public int Importancia { get; set; }
        public int Urgencia { get; set; }

    }
}
