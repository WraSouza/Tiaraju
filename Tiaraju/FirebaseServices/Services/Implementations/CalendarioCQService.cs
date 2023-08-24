using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiaraju.FirebaseServices.Services.Interfaces;
using Tiaraju.Models;

namespace Tiaraju.FirebaseServices.Services.Implementations
{
    public class CalendarioCQService : ICalendarioCQService
    {
        FirebaseClient firebase;

        public CalendarioCQService()
        {
            firebase = new FirebaseClient("https://tiaraju-afa0a-default-rtdb.firebaseio.com/");
        }

        public async Task<List<Calendario>> GetCalendarios()
        {
            
                return (await firebase.Child("CalendarioCQ")
                    .OnceAsync<Calendario>()).Select(item => new Calendario
                    {
                        Dia = item.Object.Dia,
                        Mes = item.Object.Mes,
                        Descricao = item.Object.Descricao,
                        IsFinished = item.Object.IsFinished,
                        IsExcluded = item.Object.IsExcluded,
                        FinalizadoPor = item.Object.FinalizadoPor,
                        MotivoExclusao = item.Object.MotivoExclusao,
                        Titulo = item.Object.Titulo,
                        Ano = item.Object.Ano,
                        Status = item.Object.Status

                    }).ToList();
            
        }

        public async Task<List<Calendario>> GetCurrentMonthCalendar(string month, int year)
        {
            var currentcalendar = await GetCalendarios();

            return currentcalendar.Where(a => a.Mes == month && a.Ano == year).ToList();
        }
    }
}
