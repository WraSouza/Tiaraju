using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiaraju.Models
{
    public class Calendario
    {
        public string Mes { get; set; }
        public int Dia { get; set; }
        public int Ano { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool IsFinished { get; set; }
        public bool IsExcluded { get; set; }
        public string FinalizadoPor { get; set; }
        public string MotivoExclusao { get; set; }
        public string DataFinalizacao { get; set; }
    }
}
