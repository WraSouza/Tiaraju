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
    partial class EditarAtividadeViewModel : ObservableObject
    {
        ActivityServices activityServices = new();
        DepartmentServices departmentServices = new();
        List<string> setoresEnvolvidos = new List<string>();
        List<string> setorResponsavel = new List<string>();
        public ObservableCollection<Department> Departments { get; set; } = new ObservableCollection<Department>();

        [ObservableProperty]
        public string projectname;

        [ObservableProperty]
        public string activityname;

        [ObservableProperty]
        public Department ownerdepartment;

        [ObservableProperty]
        public Department setores;

        [ObservableProperty]
        public DateTime finalDate;

        [ObservableProperty]
        public string priority;

        [ObservableProperty]
        public string status;

        public EditarAtividadeViewModel()
        {
            BuscaAtividade();
            BuscaDepartamentos();
        }

        [RelayCommand]
        async void AtualizarAtividade()
        {
            bool verificaConexao = Conectividade.VerificaConectividade();

            if(verificaConexao)
            {
                if (finalDate < DateTime.Now)
                {
                    Mensagem.MensagemDataDeveSerMaior();

                    return;
                }

                if (string.IsNullOrEmpty(Activityname))
                {
                    Mensagem.MensagemObrigatoriedadeCredenciais();

                    return;
                }

                var listadoBanco = await activityServices.GetActivityByName(Activityname,Projectname);                

                if (!(listadoBanco.EnvolvedDepartments.Contains(Setores.DepartmentAcronym)))
                {
                    listadoBanco.EnvolvedDepartments.Add(Setores.DepartmentAcronym);
                }                

                //TO DO. SE CONCLUÍDO, MUDAR STATUS ISFINISHED = TRUE.

                var atualizarAtividade = new Atividade(Projectname, Activityname, finalDate.ToShortDateString(), Priority, Status, Ownerdepartment.DepartmentAcronym, listadoBanco.EnvolvedDepartments);

                activityServices.UpdateActivity(atualizarAtividade);


                //TODO atualizar o projeto. Ver a necessidade de atualizar o projeto
                return;                
            }

            Mensagem.MensagemErroConexao();
        }

        async void BuscaDepartamentos()
        {
            bool verificaConexao = Conectividade.VerificaConectividade();

            if (verificaConexao)
            {
                var setores = await departmentServices.GetDepartments();

                foreach (var department in setores)
                {
                    Departments.Add(department);
                }
                return;
            }

            Mensagem.MensagemErroConexao();
        }

        async void BuscaAtividade()
        {
            string nomeAtividade = Preferences.Get("NomeAtividade", "default_value");
            string nomeProjeto = Preferences.Get("NomeProjeto", "default_value");

           var atividade = await activityServices.GetActivityByName(nomeAtividade, nomeProjeto);

            if (atividade != null)
            {
                Projectname = atividade.ProjectName;
                Activityname = atividade.Name;
            }
        }
    }
}
