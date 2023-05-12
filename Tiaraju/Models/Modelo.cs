using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiaraju.Models
{
    public abstract class Modelo
    {
        public string Name { get; set; }
        public string FinalDate { get; set; }
        public bool IsFinished { get; set; }
        public string Status { get; set; }        
    }
}
