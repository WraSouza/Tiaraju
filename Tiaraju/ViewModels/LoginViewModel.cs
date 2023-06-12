using Tiaraju.FirebaseServices.Services.Implementations;
using Tiaraju.Helpers;
using Tiaraju.Models;

namespace Tiaraju.ViewModels
{
    partial class LoginViewModel : ObservableObject
    {
        private int count = 0;

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
                        List<Atividade> listaAtividades = await activityServices.GetActivities();

                        List<string> departamentos = new List<string>();

                        foreach (var item in listaAtividades)
                        {
                            DateTime prazoFinal = DateTime.Parse(item.FinalDate);

                            if (prazoFinal.Month == DateTime.Today.Month)
                            {
                                int resultado = prazoFinal.Day - (DateTime.Now.Day);

                                if (resultado == 1)
                                {
                                    count++;
                                    departamentos.Add(item.OwnerDepartment);
                                }
                            }

                        }

                        if (((count > 0) && (Name == "bethania.vargas")) || (departamentos.Contains(user.Department)))
                        {
                            Mensagem.AtividadesProximasVencimento();
                        }

                        if (confirmaLogin)
                        {
                            Application.Current.MainPage = new AppShell();
                            return;
                        }

                        return;
                    }

                    Mensagem.MensagemSenhaInvalida();

                    return;
                    
                }
                
                Mensagem.MensagemUsuarioSemAutorizacao();

                return;
            }

            Mensagem.MensagemErroConexao();           

        }
    }
}
