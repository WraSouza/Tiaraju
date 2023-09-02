using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiaraju.FirebaseServices;
using Tiaraju.FirebaseServices.Services.Implementations;
using Tiaraju.Models;

namespace Tiaraju.ViewModels
{
    partial class CalendarioCQAbertosViewModel : ObservableObject
    {
        List<string> meses = new List<string>() { "Janeiro", "Fevereiro","Março","Abril","Maio","Junho","Julho","Agosto","Setembro","Outubro","Novembro","Dezembro" };

        public ObservableCollection<Calendario> Calendarios { get; set; } = new ObservableCollection<Calendario>();

        [ObservableProperty]
        public string month;

        [ObservableProperty]
        public string year;

        public CalendarioCQAbertosViewModel()
        {
            int monthid = DateTime.Today.Month;

            year = DateTime.Today.Year.ToString();

            switch (monthid)
            {
                case 1:
                    Month = "Janeiro";
                    break;

                case 2:
                    Month = "Fevereiro";
                    break;

                case 3:
                    Month = "Março";
                    break;

                case 4:
                    Month = "Abril";
                    break;

                case 5:
                    Month = "Maio";
                    break;

                case 6:
                    Month = "Junho";
                    break;

                case 7:
                    Month = "Julho";
                    break;

                case 8:
                    Month = "Agosto";
                    break;

                case 9:
                    Month = "Setembro";
                    break;

                case 10:
                    Month = "Outubro";
                    break;

                case 11:
                    Month = "Novembro";
                    break;

                case 12:
                    Month = "Dezembro";
                    break;
            }

           

            GetAllCalendarios();
        }

        [RelayCommand]
        void IrProximoMes()
        {
            int indexofmonth = meses.IndexOf(Month);

            if (indexofmonth == 11)
                return;

            Month = meses[indexofmonth + 1];           

            GetAllCalendarios();
        }

        [RelayCommand]
        void IrMesAnterior()
        {
            int indexofmonth = meses.IndexOf(Month);

            if (indexofmonth == 0)
                return;

            Month = meses[indexofmonth - 1];

            GetAllCalendarios();
        }

        [RelayCommand]
        void IrProximoAno()
        {
            int anoDesejado = int.Parse(Year) + 1;

            Year = anoDesejado.ToString();

            GetAllCalendarios();
        }

        [RelayCommand]
        void IrAnoAnterior()
        {
            int anoDesejado = int.Parse(Year) - 1;

            Year = anoDesejado.ToString();

            GetAllCalendarios();
        }

        [RelayCommand]
        async void IrParaCadastroCalendarioCQ()
        {            
            var route = $"{nameof(Views.CadastroCalendarioCQView)}";
            await Shell.Current.GoToAsync(route);
        }

        async void GetAllCalendarios()
        {
            Calendarios.Clear();

            CalendarioCQService calendarioService = new CalendarioCQService();
            var listaCalendario = await calendarioService.GetCurrentMonthCalendar(Month.ToUpper(),int.Parse(Year));            

            foreach (var calendario in listaCalendario.OrderByDescending(x => x.Dia).Reverse())
            {
                Calendarios.Add(calendario);
            }            

        }

        [RelayCommand]
        public async void AbrirCalendarioDetailView(Calendario model)
        {
            if (model is null)
            {
                return;
            }

            Preferences.Set("DiaCalendario", model.Dia);
            Preferences.Set("MesCalendario", model.Mes);
            Preferences.Set("DescricaoCalendario", model.Descricao);
            Preferences.Set("Titulo", model.Titulo);
            //Preferences.Set("StatusFinalizado", model.IsFinished);
            //Preferences.Set("StatusExcluido", model.IsExcluded);
            var route = $"{nameof(Views.CalendarioCQDetailView)}";
            await Shell.Current.GoToAsync(route);
        }

    }
}
