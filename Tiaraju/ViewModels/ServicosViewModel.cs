using System;


namespace Tiaraju.ViewModels
{
    partial class ServicosViewModel : ObservableObject
    {
        [RelayCommand]
        public async Task AbrirGLPI()
        {
            var route = $"{nameof(Views.GLPIView)}";
            await Shell.Current.GoToAsync(route);
        }
       
    }
}
