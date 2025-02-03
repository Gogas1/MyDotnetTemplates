using AvaloniaMVVM.Messaging;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaMVVM.ViewModels
{
    public partial class FormViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;

        public string FormLabel { get; }

        public RelayCommand NavigateCommand { get; }

        public FormViewModel(IMessenger messenger)
        {
            FormLabel = "Form view";
            _messenger = messenger;

            NavigateCommand = new RelayCommand(Navigate);
        }

        private void Navigate()
        {
            _messenger.Send(new MainNavigationViewChangedMessage(typeof(SomeViewModel)));
        }
    }
}
