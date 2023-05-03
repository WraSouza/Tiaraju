using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiaraju.Models
{
    public class Project
    {
        public Project(int id, string projectName, DateTime finalDate, Department departments)
        {
            Id = id;
            ProjectName = projectName;
            FinalDate = finalDate;
            Departments = departments;

            CreatedAt = DateTime.Now;
        }

        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime FinalDate { get; set; }
        public Department Departments { get; set; }
        public DateTime CreatedAt { get; set; }        
       
    }
}
