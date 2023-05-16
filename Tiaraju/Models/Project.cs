using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiaraju.Models
{
    public class Project : Modelo
    {
        public Project()
        {
            
        }
        public Project(string projectName, string finalDate)
        {            
            Name = projectName;
            FinalDate = finalDate;            
            Status = "Iniciado";
            CreatedAt = DateTime.Today.ToShortDateString();            
            Activities = new List<string>();
        }                       
              
        public string CreatedAt { get; set; }        
        public List<string> Activities { get; set; }     
        
        public void UpdateProject(Project project)
        {
            if (project == null)
            {
                return;
            }

            Name = project.Name;
            FinalDate = project.FinalDate;
            Status = project.Status;
        }

        public bool FinishProject(Project project)
        {
            IsFinished = true;

            return IsFinished;
        }
        
       
    }

    
}
