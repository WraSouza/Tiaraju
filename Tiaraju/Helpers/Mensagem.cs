using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiaraju.Helpers
{
    public class Mensagem
    {
        public static void MensagemObrigatoriedadeCredenciais()
        {
            Application.Current.MainPage.DisplayAlert("Ops!", "Necessário Informar Campos", "OK");
        }

        public static void MensagemErroConexao()
        {
            Application.Current.MainPage.DisplayAlert("Ops!", "Algo Deu Errado. Verifique Sua Conexão de Internet.", "OK");
        }

        public static void MensagemSenhaInvalida()
        {
            Application.Current.MainPage.DisplayAlert("Ops!", "Usuário ou Senha Inválida", "OK");
        }

        public static void MensagemCadastroSucesso()
        {
            Application.Current.MainPage.DisplayAlert("", "Cadastro Realizado Com Sucesso.", "OK");
        }

        public static void MensagemUsuarioInvalido()
        {
            Application.Current.MainPage.DisplayAlert("Ops!", "Usuário Informado Não Existe", "OK");
        }

        public static void MensagemEventoJaCadastrado()
        {
            Application.Current.MainPage.DisplayAlert("Ops!", "Evento Já Cadastrado.", "OK");
        }

        public static void MensagemDataDeveSerMaior()
        {
            Application.Current.MainPage.DisplayAlert("Ops!", "A Data Informada Deve Ser Posterior ou Igual a Hoje.", "OK");
        }

        public static void MensagemUsuarioSemAutorizacao()
        {
            Application.Current.MainPage.DisplayAlert("Ops!", "Usuário Sem Autorização de Acesso.", "OK");
        }

        public static void AtividadeFinalizadaComSucesso()
        {
            Application.Current.MainPage.DisplayAlert("Sucesso", "Evento Finalizado Com Sucesso.", "OK");
        }

        public static void SenhaAtualizadaComSucesso()
        {
            Application.Current.MainPage.DisplayAlert("Sucesso", "Senha Atualizada Com Sucesso.", "OK");
        }

        public static void SenhasNaoConferem()
        {
            Application.Current.MainPage.DisplayAlert("Ops!", "Senhas Informadas Não Conferem.", "OK");
        }

        public static void UsuarioCadastradoSucesso()
        {
            Application.Current.MainPage.DisplayAlert("Sucesso", "Usuário Cadastrado Com Sucesso.", "OK");
        }

        public static void MensagemExcecao()
        {
            Application.Current.MainPage.DisplayAlert("Ops", "Tivemos Um Problema na Requisição.", "OK");
        }

        public static void MensagemExclusão()
        {
            Application.Current.MainPage.DisplayAlert("", "Exclusão Realizada com Sucesso.", "OK");
        }

        public static void SucessoAtualizacao()
        {
            Application.Current.MainPage.DisplayAlert("", "Atualização Realizada com Sucesso.", "OK");
        }

        public static void AtividadesProximasVencimento()
        {
            Application.Current.MainPage.DisplayAlert("Info", "Existem Atividades Próximas Ao Vencimento", "OK");
        }
        
    }
}
