using MahAppIcons.Shared.Services;
using MahAppIcons.Shared.ViewModels;
using MahAppIcons.SharedViewModels;
using MahApps.Metro.IconPacks;
using Porrey.Controls.ColorPicker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class IconDetailsPage : Page, INotifyPropertyChanged
    {
        public SolidColorBrush SelectedColor => this.ColorPicker.SelectedColor;
        public event PropertyChangedEventHandler PropertyChanged;
        private IconDetailsViewModel ViewModel
        {
            get { return ViewModelLocator.Current.IconDetailsViewModel; }
        }
        public IconDetailsPage()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            ViewModel.IconItem = e.Parameter as IconViewModel;
            //PackIconBoxIconsDataFactory.DataIndex.Value?.TryGetValue(boxIconsKind, out data);

            //bool itemupdate = await ViewModel.GetUIelement(ViewModel.IconItem, RelativePanelParent);
            //this.UpdateLayout();
            //ViewModel.IconItem = new IconDetailsItem();
            //ViewModel.IconItem.Description = icon.Description;
            //ViewModel.IconItem.IconPackType = icon.IconPackType;
            //ViewModel.IconItem.IconType = icon.IconType;
            //ViewModel.IconItem.Name = icon.Name;
            //ViewModel.IconItem.Value = icon.Value;

            //ConnectedAnimation imageAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation("ForwardConnectedAnimation");
            //if (imageAnimation != null)
            //{
            //    // Connected animation + coordinated animation
            //    imageAnimation.TryStart(TestThumbnailitem, new UIElement[] { IconContentTemplate });

            //}
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            //ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("BackConnectedAnimation", TestThumbnailitem);
        }

        private void clrpkrColor_Changed(ColorPicker sender, ColorChangedEventArgs args)
        {
            try
            {
                sender.PreviousColor = sender.Color;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void RaisedPropertyChangedEvent([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ColorPicker_SelectedColorChanged(object sender, ValueChangedEventArgs<SolidColorBrush> e)
        {
            this.RaisedPropertyChangedEvent(nameof(this.SelectedColor));
        }
    }
}
