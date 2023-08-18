using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiaraju.Models;

namespace Tiaraju.FirebaseServices.Services.Interfaces
{
    interface ICalendarioCQService
    {
        Task<List<Calendario>> GetCalendarios();

        Task<List<Calendario>> GetCurrentMonthCalendar(string month, int year);
    }
}
