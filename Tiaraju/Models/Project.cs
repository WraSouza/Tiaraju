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
        public Project(string projectName, string finalDate,string status)
        {            
            Name = projectName;
            FinalDate = finalDate;            
            Status = status;
            CreatedAt = DateTime.Today.ToShortDateString();            
            Activities = new List<string>();
        }                       
              
        public string CreatedAt { get; set; }        
        public List<string> Activities { get; set; }
        
       
    }
}
