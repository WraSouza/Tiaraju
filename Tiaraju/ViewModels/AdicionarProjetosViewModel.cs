using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiaraju.FirebaseServices.Services;
using Tiaraju.Helpers;
using Tiaraju.Models;

namespace Tiaraju.ViewModels
{
    partial class AdicionarProjetosViewModel : ObservableObject
    {
        DepartmentServices departmentServices = new DepartmentServices();
        ProjectServices projectServices = new();

        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public Department department;

        [ObservableProperty]
        public DateTime finalDate;

        [ObservableProperty]
        public string priority;

        public ObservableCollection<Department> Departments { get; set; } = new ObservableCollection<Department>();

        public AdicionarProjetosViewModel()
        {
            BuscaDepartamentos();
        }

        [RelayCommand]
        public async void AddProject()
        {
            bool verificaConexao = Conectividade.VerificaConectividade();

            if(verificaConexao)
            {
                //Primeiro verificar se a data é maior que o dia atual
                if(finalDate <  DateTime.Now)
                {
                    Mensagem.MensagemDataDeveSerMaior();

                    return;
                }

                if (string.IsNullOrEmpty(Title))
                {
                    Mensagem.MensagemObrigatoriedadeCredenciais();

                    return;
                }
                int quantityProject = await projectServices.GetProjectsQuantity();

                var project = new Project((quantityProject + 1), Title, finalDate, Department.DepartmentName, priority);

                await projectServices.AddProject(project);

                Mensagem.MensagemCadastroSucesso();

                return;
            }

            Mensagem.MensagemErroConexao();
        }


        async void BuscaDepartamentos()
        {
            bool verificaConexao = Conectividade.VerificaConectividade();

            if(verificaConexao)
            {
                try
                {
                    var departments = await departmentServices.GetDepartments();


                    foreach (var department in departments)
                    {
                        Departments.Add(department);
                    }
                }
                catch (Exception e)
                {
                    Mensagem.MensagemExcecao();
                }

                return;
            }

            Mensagem.MensagemErroConexao();
            

        }
    }
}
