namespace Tiaraju.Views;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(GLPIView), typeof(GLPIView));

        Routing.RegisterRoute(nameof(GerenciamentoProjetosView), typeof(GerenciamentoProjetosView));

        Routing.RegisterRoute(nameof(PMOSetorView), typeof(PMOSetorView));

        Routing.RegisterRoute(nameof(AdicionarProjetoView), typeof(AdicionarProjetoView));


    }
}