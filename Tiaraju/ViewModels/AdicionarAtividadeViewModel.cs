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
    partial class AdicionarAtividadeViewModel : ObservableObject
    {
        ProjectServices projectServices = new();
        DepartmentServices departmentServices = new();
        ActivityServices activityServices = new();

        public ObservableCollection<Project> Projects { get; set; } = new ObservableCollection<Project>();
        public ObservableCollection<Department> Departments { get; set; } = new ObservableCollection<Department>();

        List<string> setoresEnvolvidos = new List<string>();        

        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public string projecttitle;

        [ObservableProperty]
        public Project project;

        [ObservableProperty]
        public DateTime finalDate;

        [ObservableProperty]
        public string priority;

        [ObservableProperty]
        public string status;

        [ObservableProperty]
        public Department setores;

        [ObservableProperty]
        public Department ownerdepartment;

        public AdicionarAtividadeViewModel()
        {
            BuscaProjetos();
            BuscaDepartamentos();

            var nomeProjeto = Preferences.Get("NomeProjeto", "default_value");

            Projecttitle = nomeProjeto.ToString();
        }

        [RelayCommand]
        public async void AddActivity()
        {
            bool verificaConexao = Conectividade.VerificaConectividade();     
            
                if (verificaConexao)
                {
                    if (finalDate < DateTime.Now)
                    {
                        Mensagem.MensagemDataDeveSerMaior();

                        return;
                    }


                    if (string.IsNullOrEmpty(Title))
                    {
                        Mensagem.MensagemObrigatoriedadeCredenciais();

                        return;
                    }

                    //Verifica se a atividade existe. Se existir, traz as informações dela para que seja atualizada
                    bool verificaSeAtividadeExiste = await activityServices.ActivityExist(Title, Projecttitle);

                    if (verificaSeAtividadeExiste)
                    {                       

                        var listadoBanco = await activityServices.GetActivityByName(Title, Projecttitle);

                       listadoBanco.EnvolvedDepartments.Add(Setores.DepartmentAcronym);
                       
                        setoresEnvolvidos.Add(Setores.ToString());

                        var atualizarAtividade = new Atividade(Projecttitle, Title, finalDate.ToShortDateString(), Priority, Status, Ownerdepartment.DepartmentAcronym, listadoBanco.EnvolvedDepartments);

                        activityServices.UpdateActivity(atualizarAtividade);

                        Mensagem.SucessoAtualizacao();

                        //TODO atualizar o projeto. Ver a necessidade de atualizar o projeto
                        return;
                    }

                    if (Status == null)
                    {
                        Status = "Em Andamento";
                    }


                    //Aqui adiciona uma nova atividade.
                    setoresEnvolvidos.Add(Setores.DepartmentAcronym);

                    var atividade = new Atividade(Projecttitle, Title.TrimEnd(), finalDate.ToShortDateString(), Priority, Status, Ownerdepartment.DepartmentAcronym, setoresEnvolvidos);

                    await activityServices.AddActivity(atividade);

                    Mensagem.MensagemCadastroSucesso();

                    return;
                }

                Mensagem.MensagemErroConexao();            
        }

        async void BuscaDepartamentos()
        {
            bool verificaConexao = Conectividade.VerificaConectividade();

            if(verificaConexao )
            {
                var setores = await departmentServices.GetDepartments();

                foreach(var department  in setores)
                {
                    Departments.Add(department);
                }
                return;
            }

            Mensagem.MensagemErroConexao();
        }
        async void BuscaProjetos()
        {
            bool verificaConexao = Conectividade.VerificaConectividade();

            if(verificaConexao)
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
