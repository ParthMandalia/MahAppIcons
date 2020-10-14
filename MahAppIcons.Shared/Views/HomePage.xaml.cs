using GalaSoft.MvvmLight.Views;
using MahAppIcons.Shared.Services;
using MahAppIcons.Shared.ViewModels;
using MahAppIcons.SharedViewModels;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.AccessControl;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MahAppIcons.Shared.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        IIconViewModel _storeditem;
        private HomePageViewModel ViewModel
        {
            get { return ViewModelLocator.Current.HomePageViewModel; }
        }

        public HomePage()
        {
            this.InitializeComponent();
        }

        private async void gbwIconsList_Loaded(object sender, RoutedEventArgs e)
        {
            var gridviewcontrol = FindControl<GridView>(MasterDetailsControl, typeof(GridView), "gvwIconsList");
            ///TODO: Connected Animations is not supported in Uwp. Will enable connected animations after Uno support
            //if (_storeditem != null)
            //{
            //    // If the connected item appears outside the viewport, scroll it into view.
            //    gridviewcontrol.ScrollIntoView(_storeditem, ScrollIntoViewAlignment.Default);
            //    gridviewcontrol.UpdateLayout();

            //    // Play the second connected animation. 
            //    ConnectedAnimation animation = ConnectedAnimationService.GetForCurrentView().GetAnimation("BackConnectedAnimation");
            //    if (animation != null)
            //    {
            //        // Setup the "back" configuration if the API is present. 
            //        if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 7))
            //        {
            //            animation.Configuration = new DirectConnectedAnimationConfiguration();
            //        }

            //        await gridviewcontrol.TryStartConnectedAnimationAsync(animation, _storeditem, "TestThumbnail");
            //    }
            //}
        }

        private void gvwIconsList_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                _storeditem = (IIconViewModel)e.ClickedItem;
                var gridviewcontrol = FindControl<GridView>(MasterDetailsControl, typeof(GridView), "gvwIconsList");
                if (gridviewcontrol != null)
                {
                    //if (gridviewcontrol.ContainerFromItem(e.ClickedItem) is GridViewItem container)
                    //{
                    //    _storeditem = container.Content as IIconViewModel;

                    //    //prepare the animation
                    //    var animation = gridviewcontrol.PrepareConnectedAnimation("ForwardConnectedAnimation", _storeditem, "IconContentTemplate");
                    //}
                    //TODO: SuppressNavigationTransitionInfo() after connected animation is enabled.
                    ViewModelLocator.Current.NavigationService.Navigate(typeof(IconDetailsViewModel).FullName, _storeditem, new DrillInNavigationTransitionInfo());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static T FindControl<T>(UIElement parent, Type targetType, string ControlName) where T : FrameworkElement
        {

            if (parent == null) return null;

            if (parent.GetType() == targetType && ((T)parent).Name == ControlName)
            {
                return (T)parent;
            }
            T result = null;
            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                UIElement child = (UIElement)VisualTreeHelper.GetChild(parent, i);

                if (FindControl<T>(child, targetType, ControlName) != null)
                {
                    result = FindControl<T>(child, targetType, ControlName);
                    break;
                }
            }
            return result;
        }
    }
}
