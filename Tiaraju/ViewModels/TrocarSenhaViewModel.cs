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
    partial class TrocarSenhaViewModel : ObservableObject
    {
        [ObservableProperty]
        public string novaSenha;

        [ObservableProperty]
        public string confirmaNovaSenha;

        [RelayCommand]
        public async void AtualizarSenha()
        {
            if((string.IsNullOrEmpty(NovaSenha))||(string.IsNullOrEmpty(ConfirmaNovaSenha)))
            {
                Mensagem.MensagemObrigatoriedadeCredenciais();

                return;
            }

            if (NovaSenha.Equals(ConfirmaNovaSenha))
            {
               UserServices userServices = new UserServices();
                var username = Preferences.Get("Nome", "default_value");

                string senhaCriptografada = Criptografia.CriptografaSenha(NovaSenha);

                await userServices.UpdatePasswordUser(username, senhaCriptografada);

                Mensagem.SenhaAtualizadaComSucesso();

                Application.Current.MainPage = new AppShell();

                return;
            }

            Mensagem.SenhasNaoConferem();

            return;
        }
    }
}
