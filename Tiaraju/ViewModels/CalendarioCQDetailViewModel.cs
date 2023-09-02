using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiaraju.FirebaseServices.Services.Implementations;
using Tiaraju.Models;

namespace Tiaraju.ViewModels
{
    partial class CalendarioCQDetailViewModel : ObservableObject
    {

        [ObservableProperty]
        public int diaatividade;

        [ObservableProperty]
        public string mesatividade;

        [ObservableProperty]
        public string titulo;

        [ObservableProperty]
        public bool entryvalue;

        [ObservableProperty]
        public bool setfalsedatepicker;

        [ObservableProperty]
        public bool editorstatus;

        [ObservableProperty]
        public DateTime? date;

        [ObservableProperty]
        public string description;

        public CalendarioCQDetailViewModel()
        {
            BuscaCalendario();
            Entryvalue = false;
            Setfalsedatepicker = false;
            Editorstatus = false;
        }

        async void BuscaCalendario()
        {
            int diaCalendario = Preferences.Get("DiaCalendario", 0);
            string mesCalendario = Preferences.Get("MesCalendario", "default_value");
            string titulo = Preferences.Get("Titulo", "default_value");
            CalendarioCQService calendarioCQService = new CalendarioCQService();

            List<Calendario> calendario = await calendarioCQService.GetCalendarios();

            var calendarioSolicitado = calendario.Where(a => a.Dia == diaCalendario && a.Mes == mesCalendario && a.Titulo == titulo);

            foreach (var dados in calendarioSolicitado)
            {
                diaatividade = dados.Dia;
                mesatividade = dados.Mes;
                Titulo = dados.Titulo;
                Date = DateTime.Parse(dados.DataFinalizacao);
                Description = dados.Descricao;
            }
        }

        [RelayCommand]
        public void AlterarStatusCampos()
        {
            Entryvalue = true;
            Setfalsedatepicker = true;
            Editorstatus = true;
        }


        //[RelayCommand]
        //public async void AbrirCalendarioDetailView(Calendario model)
        //{
        //    if (model is null)
        //    {
        //        return;
        //    }

        //    Preferences.Set("DiaCalendario", model.Dia);
        //    Preferences.Set("MesCalendario", model.Mes);
        //    Preferences.Set("DescricaoCalendario", model.Descricao);
        //    //Preferences.Set("StatusFinalizado", model.IsFinished);
        //    //Preferences.Set("StatusExcluido", model.IsExcluded);
        //    var route = $"{nameof(Views.CalendarioCQDetailView)}";
        //    await Shell.Current.GoToAsync(route);
        //}

    }
}
