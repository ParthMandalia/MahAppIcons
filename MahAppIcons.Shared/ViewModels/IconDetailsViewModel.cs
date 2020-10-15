using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MahAppIcons.Shared.Services;
using MahAppIcons.SharedViewModels;
using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace MahAppIcons.Shared.ViewModels
{
    public class IconDetailsViewModel : ViewModelBase
    {

        public IconDetailsViewModel()
        {

        }
        private IIconViewModel _iconitem;
        public IIconViewModel IconItem
        {
            get { return _iconitem; }
            set
            {
                Set(ref _iconitem, value);
            }
        }

        private Color _test;
        public Color Test
        {
            get { return _test; }
            set { Set(ref _test, value); }
        }

    }


    public class IconDetailsSettings
    {
        public double IconSize { get; set; }
        public SolidColorBrush ForegroundBrush { get; set; }

    }
    public class IconDetailsItem : ViewModelBase, IIconDetailsItem
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string TypeDescription { get; set; }

        public Type IconPackType { get; set; }

        public Type IconType { get; set; }

        public object Value { get; set; }
        public SolidColorBrush ColorValue { get; set; }
    }
}
