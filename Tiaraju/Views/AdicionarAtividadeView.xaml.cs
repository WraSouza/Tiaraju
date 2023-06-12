namespace Tiaraju.Views;

public partial class AdicionarAtividadeView : ContentPage
{
	public AdicionarAtividadeView()
	{
		InitializeComponent();

        datePicker.Date = DateTime.Now;
    }

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        double novoValor = e.NewValue;

        if(novoValor < 2)
        {
            boxview1.Color = Color.FromArgb("00FF00");
            boxview2.Color = Color.FromArgb("FFFFFF");
            boxview3.Color = Color.FromArgb("FFFFFF");
            boxview4.Color = Color.FromArgb("FFFFFF");
            boxview5.Color = Color.FromArgb("FFFFFF");

        }else if(novoValor < 3)
        {
            boxview1.Color = Color.FromArgb("00FF00");
            boxview2.Color = Color.FromArgb("00FF00");
            boxview3.Color = Color.FromArgb("FFFFFF");
            boxview4.Color = Color.FromArgb("FFFFFF");
            boxview5.Color = Color.FromArgb("FFFFFF");
        }else if (novoValor < 4)
        {
            boxview1.Color = Color.FromArgb("FFFF00");
            boxview2.Color = Color.FromArgb("FFFF00");
            boxview3.Color = Color.FromArgb("FFFF00");
            boxview4.Color = Color.FromArgb("FFFFFF");
            boxview5.Color = Color.FromArgb("FFFFFF");
        }else if (novoValor < 5)
        {
            boxview1.Color = Color.FromArgb("FF0000");
            boxview2.Color = Color.FromArgb("FF0000");
            boxview3.Color = Color.FromArgb("FF0000");
            boxview4.Color = Color.FromArgb("FF0000");
            boxview5.Color = Color.FromArgb("FFFFFF");
        }
        else
        {
            boxview1.Color = Color.FromArgb("FF0000");
            boxview2.Color = Color.FromArgb("FF0000");
            boxview3.Color = Color.FromArgb("FF0000");
            boxview4.Color = Color.FromArgb("FF0000");
            boxview5.Color = Color.FromArgb("FF0000");
        }

        Preferences.Set("ValorSliderUrgencia", (int)e.NewValue);

    }

    private void AlterarImportancia(object sender, ValueChangedEventArgs e)
    {
        double novoValor = e.NewValue;

        if (novoValor < 2)
        {
            boxview6.Color = Color.FromArgb("00FF00");
            boxview7.Color = Color.FromArgb("FFFFFF");
            boxview8.Color = Color.FromArgb("FFFFFF");
            boxview9.Color = Color.FromArgb("FFFFFF");
            boxview10.Color = Color.FromArgb("FFFFFF");

        }
        else if (novoValor < 3)
        {
            boxview6.Color = Color.FromArgb("00FF00");
            boxview7.Color = Color.FromArgb("00FF00");
            boxview8.Color = Color.FromArgb("FFFFFF");
            boxview9.Color = Color.FromArgb("FFFFFF");
            boxview10.Color = Color.FromArgb("FFFFFF");
        }
        else if (novoValor < 4)
        {
            boxview6.Color = Color.FromArgb("FFFF00");
            boxview7.Color = Color.FromArgb("FFFF00");
            boxview8.Color = Color.FromArgb("FFFF00");
            boxview9.Color = Color.FromArgb("FFFFFF");
            boxview10.Color = Color.FromArgb("FFFFFF");
        }
        else if (novoValor < 5)
        {
            boxview6.Color = Color.FromArgb("FF0000");
            boxview7.Color = Color.FromArgb("FF0000");
            boxview8.Color = Color.FromArgb("FF0000");
            boxview9.Color = Color.FromArgb("FF0000");
            boxview10.Color = Color.FromArgb("FFFFFF");
        }
        else
        {
            boxview6.Color = Color.FromArgb("FF0000");
            boxview7.Color = Color.FromArgb("FF0000");
            boxview8.Color = Color.FromArgb("FF0000");
            boxview9.Color = Color.FromArgb("FF0000");
            boxview10.Color = Color.FromArgb("FF0000");
        }

        Preferences.Set("ValorSliderImportancia", (int)e.NewValue);
    }
}