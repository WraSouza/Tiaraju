using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiaraju.ViewModels.STViewModels
{
    partial class STMainViewModel : ObservableObject
    {
        [RelayCommand]
        public async Task AbrirExtintoresView()
        {
            var route = $"{nameof(Views.ST.ExtintoresView)}";
            await Shell.Current.GoToAsync(route);
        }
    }
}
