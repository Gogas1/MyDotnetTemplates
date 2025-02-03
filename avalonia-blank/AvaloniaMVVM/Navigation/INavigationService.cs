using AvaloniaMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaMVVM.Navigation
{
    public interface INavigationService
    {
        void NavigateTo<TViewModel>() where TViewModel : ViewModelBase ;
    }
}
