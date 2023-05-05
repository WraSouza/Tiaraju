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

        public GerenciamentoProjetosViewModel()
        {
            GetProjects();
        }


        [RelayCommand]
        public async Task AdicionarProjetos()
        {
            var route = $"{nameof(Views.AdicionarProjetoView)}";
            await Shell.Current.GoToAsync(route);
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
