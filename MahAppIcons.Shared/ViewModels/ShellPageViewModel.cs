using GalaSoft.MvvmLight;
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
using Windows.UI.Xaml.Data;

namespace MahAppIcons.Shared.ViewModels
{
    public class ShellPageViewModel : ViewModelBase
    {

        public ShellPageViewModel()
        {
            Onloaded();
        }

        public async void Onloaded()
        {
            //IconPackCollection = await IconPackList.CreateIconPackList(this);
        }

        private ObservableCollection<IconPackViewModel> _iconpackCollection = new ObservableCollection<IconPackViewModel>();
        public ObservableCollection<IconPackViewModel> IconPackCollection
        {
            get { return _iconpackCollection; }
            set { Set(ref _iconpackCollection, value); }
        }
    }
}
