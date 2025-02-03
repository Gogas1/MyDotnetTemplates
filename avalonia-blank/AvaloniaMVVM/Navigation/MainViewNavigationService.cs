using AvaloniaMVVM.Messaging;
using AvaloniaMVVM.ViewModels;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaMVVM.Navigation
{
    public class MainViewNavigationService : ViewNavigationServiceBase
    {
        private readonly IMessenger _messenger;

        public MainViewNavigationService(Func<Type, ViewModelBase> viewModelFactory, IMessenger messenger) : base(viewModelFactory)
        {
            _messenger = messenger;
            _messenger.Register<MainNavigationViewChangedMessage>(this, NavigationMessageHandler);
        }

        private void NavigationMessageHandler(object recipient, MainNavigationViewChangedMessage message)
        {
            NavigateTo(message.Value);
        }        
    }
}
