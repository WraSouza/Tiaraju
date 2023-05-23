using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiaraju.FirebaseServices.Services.Implementations;
using Tiaraju.Models;

namespace Tiaraju.ViewModels
{
    partial class ProjectStatisticsViewModel : ObservableObject
    {
        ActivityServices activityServices = new();

        [ObservableProperty]
        public string projectname;

        [ObservableProperty]
        public string quantidadetotal;

        [ObservableProperty]
        public string quantidadenoprazo;

        [ObservableProperty]
        public string quantidadeematraso;

        [ObservableProperty]
        public string concluidos;


        public ProjectStatisticsViewModel()
        {
            BuscaAtividades();
        }

        async void BuscaAtividades()
        {
            var projetoNome = Preferences.Get("NomeProjeto", "default_value");

            List<Atividade> listaAtividades = await activityServices.GetAtividade(projetoNome);

            Projectname = projetoNome;

            Quantidadetotal = listaAtividades.Count().ToString();

            int projetosAtrasados = listaAtividades.Where(a => DateTime.Parse(a.FinalDate) < DateTime.Today).Count();

            Quantidadeematraso = projetosAtrasados.ToString();

            int projetosEmDia = listaAtividades.Where(a => DateTime.Parse(a.FinalDate) >= DateTime.Today).Count();

            Quantidadenoprazo = projetosEmDia.ToString();

            int projetosConcluidos = listaAtividades.Where(p => p.IsFinished == true).Count();

            Concluidos = projetosConcluidos.ToString();
        }
    }
}
