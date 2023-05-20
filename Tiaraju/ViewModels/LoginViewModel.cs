﻿using Tiaraju.FirebaseServices.Services.Implementations;
using Tiaraju.Helpers;
using Tiaraju.Models;

namespace Tiaraju.ViewModels
{
    partial class LoginViewModel : ObservableObject
    {

        [ObservableProperty]
        public string name;

        [ObservableProperty]
        public string password;

        [ObservableProperty]
        public string isbusy;

        [RelayCommand]
        public async Task Login()
        {           

            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Password))
            {
                Mensagem.MensagemObrigatoriedadeCredenciais();

                return;
            }

            Name = Name.Replace(" ", "");

            Preferences.Set("Nome", Name);

            UserServices userServices = new UserServices();

            ActivityServices activityServices = new ActivityServices();

            bool verificaConexao = Conectividade.VerificaConectividade();

            if(verificaConexao)
            {
                Usuario user = await userServices.GetUser(Name);

                activityServices.ChangeStatusToLate();

                if(user.IsActive == true)
                {                    

                    if(user.Password.Equals("1234"))
                    {
                        Application.Current.MainPage = new AtualizarSenhaView();

                        return;
                    }

                    Usuario usuario = await userServices.GetUser(Name);

                    Preferences.Set("Departamento", usuario.Department);                    

                    string senhaCriptografada = Criptografia.CriptografaSenha(Password);

                    bool confirmaLogin = await userServices.LoginUser(Name,senhaCriptografada);

                    if(confirmaLogin)
                    {
                        Application.Current.MainPage = new AppShell();
                        return;
                    }
                    
                }

                Mensagem.MensagemUsuarioSemAutorizacao();

                return;
            }

            Mensagem.MensagemErroConexao();           

        }
    }
}
