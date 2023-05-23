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
    partial class GerenciamentoProjetosViewModel : ObservableObject
    {
        public ObservableCollection<Project> Projects { get; set; } = new ObservableCollection<Project>();

        ProjectServices projectServices = new();

        [ObservableProperty]
        public bool isRefreshing;

        public GerenciamentoProjetosViewModel()
        {
            GetProjects();
        }

        [RelayCommand]
        async void AbrirProjetoDetail(Project project)
        {
            Preferences.Set("NomeProjeto", project.Name);
            var route = $"{nameof(Views.ProjectDetailView)}";
            await Shell.Current.GoToAsync(route);
        }

        [RelayCommand]
        public void AtualizarTela()
        {
            bool verificaConexao = Conectividade.VerificaConectividade();

            if( verificaConexao )
            {
                Projects.Clear();
                GetProjects();

                IsRefreshing = false;
            }
        }


        [RelayCommand]
        public async Task AdicionarProjetos()
        {
            var nomeUsuario = Preferences.Get("Nome", "default_value");

            if(nomeUsuario == "bethania.vargas")
            {
                var route = $"{nameof(Views.AdicionarProjetoView)}";
                await Shell.Current.GoToAsync(route);
            }
            else
            {
                Mensagem.MensagemUsuarioSemAutorizacao();
            }            
        }

        [RelayCommand]
        public async Task AbrirStatisticsView(Project project)
        {
            var nomeUsuario = Preferences.Get("Nome", "default_value");

            Preferences.Set("NomeProjeto", project.Name);

            if (nomeUsuario == "bethania.vargas")
            {
                var route = $"{nameof(Views.ProjectStatisticsView)}";
                await Shell.Current.GoToAsync(route);
            }
            else
            {
                Mensagem.MensagemUsuarioSemAutorizacao();
            }
        }

        async void GetProjects()
        {
            bool verificaConexao = Conectividade.VerificaConectividade();

            if (verificaConexao)
            {
                var projects = await projectServices.GetProjects();                

                foreach (var project in projects)
                {
                    Projects.Add(project);
                }

                return;
            }

            Mensagem.MensagemErroConexao();

        }
    }
}
