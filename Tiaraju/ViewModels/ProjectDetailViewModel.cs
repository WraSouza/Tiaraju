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
        public ObservableCollection<Atividade> Atividades { get; set; } = new ObservableCollection<Atividade>();

        public ObservableCollection<string> OwnerDepartments { get; set; } = new ObservableCollection<string>();

        public ProjectDetailViewModel()
        {
            BuscaAtividades();
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
