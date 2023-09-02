using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiaraju.FirebaseServices.Services.Implementations;
using Tiaraju.Helpers;
using Tiaraju.Models;

namespace Tiaraju.ViewModels
{
    partial class CadastroCalendarioCQViewModel : ObservableObject
    {
        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public DateTime dataatividade;

        [ObservableProperty]
        public string description;

        [RelayCommand]
        async void Cadastrar()
        {
            string mesAtividade = Dataatividade.ToString("MMMM").ToUpper();
            int diaAtividade = Dataatividade.Day;

            if(Dataatividade < DateTime.Now)
            {
                Mensagem.MensagemDataDeveSerMaior();
                return;
            }

            Calendario newCalendar = new Calendario(mesAtividade, diaAtividade, Dataatividade.Year, Title, Description);
            CalendarioCQService calendarioService = new();
            await calendarioService.CadastrarCalendario(newCalendar);
        }
    }
}
