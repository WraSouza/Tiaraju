using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiaraju.FirebaseServices.Services.Implementations;
using Tiaraju.Models;

namespace Tiaraju.ViewModels
{
    partial class ProjectDetailViewModel : ObservableObject
    {
        ActivityServices activityServices = new();
        ProjectServices projectServices = new();
        public List<ChartsAtividades> Lista { get; set; }        
        public ObservableCollection<Atividade> Atividades { get; set; } = new ObservableCollection<Atividade>();
        public ObservableCollection<string> OwnerDepartments { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<ChartsAtividades> Charts { get; set; } = new ObservableCollection<ChartsAtividades>();

        public ProjectDetailViewModel()
        {
            BuscaAtividades();
            PreencherGrafico();
        }

        async void PreencherGrafico()
        {
            //Lista = new List<ChartsAtividades>()
            //{
            //    new ChartsAtividades() { ProjectName = "Teste", QuantidadeAtividades = 1},
            //    new ChartsAtividades() { ProjectName = "Teste1", QuantidadeAtividades = 2},
            //    new ChartsAtividades() { ProjectName = "Teste2", QuantidadeAtividades = 3},
            //    new ChartsAtividades() { ProjectName = "Teste3", QuantidadeAtividades = 4},
            //};

            var listaProjetos = await projectServices.GetProjects();

            Lista = new List<ChartsAtividades>()
            {

            };

            //foreach (var project in listaProjetos)
            //{
            //    int quantidadeAtividades = await activityServices.ReturnActivityQuantity(project.Name);
            //    string nomeprojeto = project.Name;
            //    Lista = new List<ChartsAtividades>()
            //    {
            //        new ChartsAtividades() { ProjectName = nomeprojeto, QuantidadeAtividades = quantidadeAtividades },
            //    };
            //}



            //foreach (var project in listaProjetos)
            //{
            //    int quantidadeAtividades = await activityServices.ReturnActivityQuantity(project.Name);

            //    var chartsProject = new ChartsAtividades(project.Name, quantidadeAtividades);

            //    //Charts.Add(chartsProject);

            //    Lista = new List<ChartsAtividades>()
            //    {
            //      new ChartsAtividades(){ ProjectName =  project.Name, QuantidadeAtividades = quantidadeAtividades },
            //    };   

            //}

            //Charts.Add(Lista);
        }

        async void BuscaAtividades()
        {
            var nomeProjeto = Preferences.Get("NomeProjeto", "default_value");            

            var nomeUsuario = Preferences.Get("Nome", "default_value");

            if(nomeUsuario == "bethania.vargas")
            {
                var detalhesProjeto = await activityServices.GetAtividade(nomeProjeto);

                foreach (var project in detalhesProjeto)
                {
                    Atividades.Add(project);
                    OwnerDepartments.Add(project.EnvolvedDepartments.ToString());
                }

                return;
            }

            var departamentoUsuario = Preferences.Get("Departamento", "default_value");

            var detalhesDoProjeto = await activityServices.GetActivityByDepartment(departamentoUsuario);

            foreach (var project in detalhesDoProjeto)
            {
                Atividades.Add(project);
                OwnerDepartments.Add(project.EnvolvedDepartments.ToString());
            }

            return;

        }

        [RelayCommand]
        public async Task AbrirAdicionarAtividadeView()
        {
            var route = $"{nameof(Views.AdicionarAtividadeView)}";
            await Shell.Current.GoToAsync(route);
        }

        [RelayCommand]
        public async Task AbrirEditarAtividadeView(Atividade atividade)
        {            
            Preferences.Set("NomeAtividade", atividade.Name);
            Preferences.Set("NomeProjeto", atividade.ProjectName);

            var route = $"{nameof(Views.EditarAtividadeView)}";
            await Shell.Current.GoToAsync(route);
        }
    }
   
}
