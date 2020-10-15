﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MahAppIcons.Shared.Services;
using MahAppIcons.SharedViewModels;
using MahApps.Metro.IconPacks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage.Search;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;

namespace MahAppIcons.Shared.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        public HomePageViewModel()
        {
            Onloaded();
        }
        public async void Onloaded()
        {
            IconPackCollection = await IconPackList.CreateIconPackList(this);
        }

        private ObservableCollection<IconPackViewModel> _iconpackCollection = new ObservableCollection<IconPackViewModel>();
        public ObservableCollection<IconPackViewModel> IconPackCollection
        {
            get { return _iconpackCollection; }
            set { Set(ref _iconpackCollection, value); }
        }

        private IconPackViewModel _iconpackselecteditem;
        public IconPackViewModel IconPackSelectedItem
        {
            get { return _iconpackselecteditem; }
            set { Set(ref _iconpackselecteditem, value); }
        }

        private ICommand _settingspageclick;
        public ICommand SettingsPageClick => _settingspageclick ?? (_settingspageclick = new RelayCommand(SettingsPageNav));

        private void SettingsPageNav()
        {
            ViewModelLocator.Current.NavigationService.Navigate(typeof(SettingsViewModel).FullName, null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
        }

    }
}
