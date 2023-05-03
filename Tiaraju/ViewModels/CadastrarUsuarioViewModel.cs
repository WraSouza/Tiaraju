using Firebase.Database;
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
    partial class CadastrarUsuarioViewModel : ObservableObject
    {
        UserServices userServices = new UserServices();
        RoleServices roleServices = new RoleServices();
        DepartmentServices departmentServices = new DepartmentServices();

        public ObservableCollection<Role> Roles { get; set; } = new ObservableCollection<Role>();
        public ObservableCollection<Department> Departments { get; set; } = new ObservableCollection<Department>();


        [ObservableProperty]
        public string name;

        [ObservableProperty]
        public string username;

        [ObservableProperty]
        public Department department;

        [ObservableProperty]
        public Role role;

        public CadastrarUsuarioViewModel()
        {
           BuscaPosicoes();
           BuscaDepartamentos();
        }


        [RelayCommand]
        async void CadastrarUsuario()
        {
            if(string.IsNullOrEmpty(username)|| string.IsNullOrEmpty(name) || string.IsNullOrEmpty(Department.DepartmentName))
            {
                Mensagem.MensagemObrigatoriedadeCredenciais();
            }

            bool verificaConexao = Conectividade.VerificaConectividade();

            if(verificaConexao)
            {
                try
                {
                    string selectedDepartment = Department.DepartmentName;
                    string selectedRole = Role.RoleName;

                    int quantidadeUsuariosBanco = await userServices.GetUsersQuantity();

                    Username = Username.Replace(" ", "");

                    var novoUsuario = new Usuario((quantidadeUsuariosBanco + 1), Name, Username, selectedDepartment, selectedRole);

                    bool confirmaCadastroUsuario = await userServices.AddUser(novoUsuario);

                    if (confirmaCadastroUsuario)
                    {
                        Mensagem.UsuarioCadastradoSucesso();
                    }

                   
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                return;
            }

            Mensagem.MensagemErroConexao();
           
        }
        

       
        async void BuscaPosicoes()
        {
            try
            {
               var posicoes = await roleServices.GetRoles();
                

                foreach (var role in posicoes)
                {                   
                    //Roles.Add(new Role() { Id = role.Id, RoleName = role.RoleName });
                    Roles.Add(role);
                }
            }catch(Exception e)
            {
                Mensagem.MensagemExcecao();
            }
           
        }

        async void BuscaDepartamentos()
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

        }
    }
}
