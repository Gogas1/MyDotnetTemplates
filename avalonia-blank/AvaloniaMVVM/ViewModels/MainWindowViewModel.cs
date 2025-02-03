using AvaloniaMVVM.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaMVVM.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private MainViewNavigationService _navigation;        

        public MainWindowViewModel(MainViewNavigationService navigation)
        {
            Navigation = navigation;

            Navigation.NavigateTo<FormViewModel>();
        }

        public MainWindowViewModel()
        {
            
        }
    }
}
