using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiaraju.Models
{
    public class Project
    {
        public Project()
        {
            
        }
        public Project(int id, string projectName, DateTime finalDate, string departments, string priority)
        {
            Id = id;
            ProjectName = projectName;
            FinalDate = finalDate;
            Departments = departments;

            CreatedAt = DateTime.Today.Date;
            Priority = priority;
        }

        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime FinalDate { get; set; }
        public string Departments { get; set; }
        public string Priority { get; set; }
        public DateTime CreatedAt { get; set; }        
       
    }
}
