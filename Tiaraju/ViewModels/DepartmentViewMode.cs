using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiaraju.ViewModels
{
    partial class DepartmentViewMode : ObservableObject
    {
        [RelayCommand]
        public async Task AbrirCalendarioCQ()
        {
            var route = $"{nameof(Views.CQMainView)}";
            await Shell.Current.GoToAsync(route);
        }

        [RelayCommand]
        public async Task AbrirManutencaoView()
        {
            var route = $"{nameof(Views.MAN.ManutencaoPrincipalView)}";
            await Shell.Current.GoToAsync(route);
        }
    }
}
