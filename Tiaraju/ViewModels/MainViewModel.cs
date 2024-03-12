using Tiaraju.FirebaseServices.Services.Implementations;
using Tiaraju.Models;

namespace Tiaraju.ViewModels;

public partial class MainViewModel : ObservableObject
{
    UserServices userServices = new();

    [ObservableProperty]
    public string nomeusuario;

    public MainViewModel()
    {
        BuscaUsuario();
    }

    async void BuscaUsuario()
    {
        var nomeUsuario = Preferences.Get("Nome", "default_value");
        var lista = await userServices.GetUser(nomeUsuario);

        Nomeusuario = lista.Name;
    }

    [RelayCommand]
    public async Task AbrirGLPI()
    {
        var route = $"{nameof(Views.GLPIView)}";
        await Shell.Current.GoToAsync(route);
    }

    [RelayCommand]
    public async Task AbrirCalendarioCQ()
    {
        var route = $"{nameof(Views.CQMainView)}";
        await Shell.Current.GoToAsync(route);
    }

}
