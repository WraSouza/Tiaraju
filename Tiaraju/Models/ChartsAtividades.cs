using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiaraju.Models
{
    public class ChartsAtividades
    {
        public ChartsAtividades()
        {
            
        }
        public ChartsAtividades(string projectName, int quantidadeAtividades)
        {
            ProjectName = projectName;
            QuantidadeAtividades = quantidadeAtividades;
        }

        public string ProjectName { get; set; }
        public int QuantidadeAtividades { get; set; }
    }
}
