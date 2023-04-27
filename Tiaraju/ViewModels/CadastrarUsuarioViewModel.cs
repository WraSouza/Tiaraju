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
        int quantidadeUsuarios;
        [ObservableProperty]
        public string name;

        [ObservableProperty]
        public string username;

        [ObservableProperty]
        public string department;
        

        [RelayCommand]
        async void CadastrarUsuario()
        {
            if(string.IsNullOrEmpty(username)|| string.IsNullOrEmpty(name) || string.IsNullOrEmpty(Department))
            {
                Mensagem.MensagemObrigatoriedadeCredenciais();
            }

            bool verificaConexao = Conectividade.VerificaConectividade();

            if(verificaConexao)
            {
                try
                {
                    var userServices = new UserServices();

                    int quantidadeUsuariosBanco = await userServices.GetUsersQuantity();

                    Username = Username.Replace(" ", "");

                    var novoUsuario = new Usuario((quantidadeUsuariosBanco + 1), Name, Username, Department);

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
    }
}
