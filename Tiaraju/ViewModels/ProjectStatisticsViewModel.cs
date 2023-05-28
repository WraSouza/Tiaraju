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

        [ObservableProperty]
        public string porcentagem;

        [ObservableProperty]
        public string radial;


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

            int projetosAtrasados = listaAtividades.Where(a => (DateTime.Parse(a.FinalDate) < DateTime.Today) && a.IsFinished == false).Count();

            Quantidadeematraso = projetosAtrasados.ToString();

            int projetosEmDia = listaAtividades.Where(a => (DateTime.Parse(a.FinalDate) >= DateTime.Today) && a.IsFinished == false).Count();

            Quantidadenoprazo = projetosEmDia.ToString();

            int projetosConcluidos = listaAtividades.Where(p => p.IsFinished == true).Count();

            Concluidos = projetosConcluidos.ToString();

            if(listaAtividades.Count > 0)
            {
                int porcentagem = (projetosConcluidos * 100) / listaAtividades.Count;

                Porcentagem = porcentagem.ToString();
            }
            else
            {
                Porcentagem = "0";
            }            

            Radial = Concluidos;
            

        }
    }
}
