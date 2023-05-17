namespace Tiaraju;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        //MainPage = new MainPage(new MainViewModel());
        MainPage = new LoginView();       
        
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        // return base.CreateWindow(activationState);
        var window = base.CreateWindow(activationState);

        const int newWidth = 800;
        const int newHeight = 750;

        window.X = 500;
        window.Y = 80;

        window.Width = newWidth;
        window.Height = newHeight;      

        return window;
    }
}
