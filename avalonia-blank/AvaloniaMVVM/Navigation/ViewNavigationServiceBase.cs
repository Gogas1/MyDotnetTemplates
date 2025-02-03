using AvaloniaMVVM.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaMVVM.Navigation
{
    public partial class ViewNavigationServiceBase : ObservableObject, INavigationService
    {
        protected readonly Func<Type, ViewModelBase> _viewModelFactory;

        public ViewNavigationServiceBase(Func<Type, ViewModelBase> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        [ObservableProperty]
        public ViewModelBase currentView;

        public virtual void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
        {
            NavigateTo(typeof(TViewModel));
        }

        protected virtual void NavigateTo(Type viewModelType)
        {
            ViewModelBase viewModel = _viewModelFactory.Invoke(viewModelType);

            CurrentView = viewModel;
        }
    }
}
