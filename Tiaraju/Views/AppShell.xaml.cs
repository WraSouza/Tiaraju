namespace Tiaraju.Views;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(GLPIView), typeof(GLPIView));

        Routing.RegisterRoute(nameof(GerenciamentoProjetosView), typeof(GerenciamentoProjetosView));

    }
}