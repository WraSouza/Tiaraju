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

        public INavigation _navigation { get; set; }

        public ObservableCollection<Department> Departments { get; set; } = new ObservableCollection<Department>();

        public AdicionarProjetosViewModel()
        {
            BuscaDepartamentos();           
        }


        [RelayCommand]
        public async void AddProject()
        {
            bool verificaConexao = Conectividade.VerificaConectividade();

            var nomeUsuario = Preferences.Get("Nome", "default_value");

           
                if (verificaConexao)
                {
                    //Primeiro verificar se a data é maior que o dia atual
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

                    var project = new Project(Title.TrimEnd(), finalDate.ToShortDateString());

                    bool verificaSeProjetoExiste = await projectServices.ProjectExist(Title.TrimEnd());

                if(verificaSeProjetoExiste)
                {
                    await Application.Current.MainPage.DisplayAlert("", "Projeto Já Existe", "OK");

                    return;
                }

                    await projectServices.AddProject(project);

                    Mensagem.MensagemCadastroSucesso();

                    await Task.Delay(2000);

                    bool answer = await Application.Current.MainPage.DisplayAlert("", "Gostaria de Adicionar uma Atividade a Esse Projeto?", "Sim", "Não");

                    Preferences.Set("NomeProjeto", Title);

                    if (answer)
                    {
                        var route = $"{nameof(Views.AdicionarAtividadeView)}";
                        await Shell.Current.GoToAsync(route);
                    }


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
