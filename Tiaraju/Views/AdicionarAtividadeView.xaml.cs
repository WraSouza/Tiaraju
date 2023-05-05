namespace Tiaraju.Views;

public partial class AdicionarAtividadeView : ContentPage
{
	public AdicionarAtividadeView()
	{
		InitializeComponent();

        datePicker.Date = DateTime.Now;
    }
}