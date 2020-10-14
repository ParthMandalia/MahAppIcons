using System;

using MahAppIcons.Shared.Services;
using MahAppIcons.Shared.Views;

using GalaSoft.MvvmLight.Ioc;
using MahAppIcons.SharedViewModels;

namespace MahAppIcons.Shared.ViewModels
{
    [Windows.UI.Xaml.Data.Bindable]
    public class ViewModelLocator
    {
        private static ViewModelLocator _current;

        public static ViewModelLocator Current => _current ?? (_current = new ViewModelLocator());

        private ViewModelLocator()
        {
            SimpleIoc.Default.Register(() => new NavigationServiceEx());
            SimpleIoc.Default.Register<ShellPageViewModel>();
            SimpleIoc.Default.Register<IconPackViewModel>();
            Register<HomePageViewModel, HomePage>();
            Register<IconDetailsViewModel, IconDetailsPage>();
        }

        public HomePageViewModel HomePageViewModel => SimpleIoc.Default.GetInstance<HomePageViewModel>();

        public IconDetailsViewModel IconDetailsViewModel => SimpleIoc.Default.GetInstance<IconDetailsViewModel>();

        public ShellPageViewModel ShellPageViewModel => SimpleIoc.Default.GetInstance<ShellPageViewModel>();

        public NavigationServiceEx NavigationService => SimpleIoc.Default.GetInstance<NavigationServiceEx>();

        public void Register<VM, V>()
            where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            NavigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
