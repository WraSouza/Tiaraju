using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiaraju.Models
{
    internal class CalendarioGroupGQ : ObservableCollection<Calendario>
    {
        public string Dia { get; private set; }

        public CalendarioGroupGQ(string dia, ObservableCollection<Calendario> calendario) : base(calendario)
        {
            Dia = dia;
        }

        public override string ToString()
        {
            return Dia;
        }
    }
}
