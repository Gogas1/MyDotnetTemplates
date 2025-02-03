using AvaloniaMVVM.ViewModels;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaMVVM.Messaging
{
    public class MainNavigationViewChangedMessage : ValueChangedMessage<Type>
    {
        public MainNavigationViewChangedMessage(Type value) : base(value)
        {
        }
    }
}
