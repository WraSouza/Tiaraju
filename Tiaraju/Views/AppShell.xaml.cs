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

        Routing.RegisterRoute(nameof(AdicionarAtividadeView), typeof(AdicionarAtividadeView));

        Routing.RegisterRoute(nameof(ProjectDetailView), typeof(ProjectDetailView));

        Routing.RegisterRoute(nameof(EditarAtividadeView), typeof(EditarAtividadeView));        

        Routing.RegisterRoute(nameof(ChartsPMOView), typeof(ChartsPMOView));

        Routing.RegisterRoute(nameof(ProjectStatisticsView), typeof(ProjectStatisticsView));       

        Routing.RegisterRoute(nameof(CalendariosCQ), typeof(CalendariosCQ));

        Routing.RegisterRoute(nameof(CadastroCalendarioCQView), typeof(CadastroCalendarioCQView));

        Routing.RegisterRoute(nameof(CalendarioCQDetailView), typeof(CalendarioCQDetailView));

    }
}