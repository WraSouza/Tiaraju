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

            var detalhesProjeto = await activityServices.GetAtividade(nomeProjeto);

            foreach(var project in detalhesProjeto)
            {
                Atividades.Add(project);
                OwnerDepartments.Add(project.EnvolvedDepartments.ToString());
            }
        }
    }
}
