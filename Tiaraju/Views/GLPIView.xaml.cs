

namespace Tiaraju.Views;

public partial class GLPIView : ContentPage
{
	public GLPIView()
	{
        InitializeComponent();

        navegador.Source = "https://laboratoriotiaraju.verdanadesk.com/index.php?noAUTO=1";
    }

    private void carregandoPagina(object sender, WebNavigatingEventArgs e)
    {
        lblStatus.Text = "Carregando Página...";
    }

    private void paginaCarregada(object sender, WebNavigatedEventArgs e)
    {
        lblStatus.Text = "Pronto";
    }
}