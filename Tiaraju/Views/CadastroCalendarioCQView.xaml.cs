namespace Tiaraju.Views;

public partial class CadastroCalendarioCQView : ContentPage
{
	public CadastroCalendarioCQView()
	{
		InitializeComponent();

        datePicker.Date = DateTime.Now;
    }
}