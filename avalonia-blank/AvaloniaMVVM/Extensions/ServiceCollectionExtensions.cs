using AvaloniaMVVM.Navigation;
using AvaloniaMVVM.ViewModels;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaMVVM.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<FormViewModel>();
            services.AddSingleton<SomeViewModel>();

            services.AddSingleton<Func<Type, ViewModelBase>>(serviceProvider => viewModelType =>
            {
                return (ViewModelBase)serviceProvider.GetRequiredService(viewModelType);
            });

            return services;
        }

        public static IServiceCollection AddNavigationServices(this IServiceCollection services)
        {
            services.AddSingleton<MainViewNavigationService>();

            return services;
        }

        public static IServiceCollection AddMessenger(this IServiceCollection services)
        {
            services.AddSingleton<IMessenger, WeakReferenceMessenger>();

            return services;
        }
    }
}
