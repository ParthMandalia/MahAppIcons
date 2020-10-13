using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MahAppIcons.Shared.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Windows.UI.Core;
using Windows.UI.Xaml.Data;

namespace MahAppIcons.SharedViewModels
{
    public class IconPackViewModel : ViewModelBase
    {
        private IEnumerable<IIconViewModel> _icons;
        private ObservableCollection<IIconViewModel> _iconlist;
        private int _iconCount;
        private ICollectionView _iconsCollectionView;
        private string _filterText;
        private IIconViewModel _selectedIcon;

        [PreferredConstructor()]
        public IconPackViewModel(HomePageViewModel mainViewModel, string caption, Type enumType, Type packType) : base()
        {
            this.MainViewModel = mainViewModel;
            this.Caption = caption;

            LoadIcons(enumType, packType);
        }

        private async void LoadIcons(Type enumType, Type packType)
        {
            await LoadEnumsAsync(enumType, packType);
        }
        private async void LoadIcons(Type[] enumTypes, Type[] packTypes)
        {
            await LoadAllEnumsAsync(enumTypes, packTypes);
        }
        private async Task LoadEnumsAsync(Type enumType, Type packType)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
                var collection = await Task.Run(() => GetIcons(enumType, packType).OrderBy(i => i.Name, StringComparer.InvariantCultureIgnoreCase).ToList());

                Icons = new ObservableCollection<IIconViewModel>(collection);
                IconList = new ObservableCollection<IIconViewModel>(Icons.ToList());
                IconCount = ((ICollection)Icons).Count;
                PrepareFiltering();
                SelectedIcon = Icons.First();
            });
        }

        public IconPackViewModel(HomePageViewModel mainViewModel, string caption, Type[] enumTypes, Type[] packTypes)
        {
            this.MainViewModel = mainViewModel;
            Caption = caption;

            LoadIcons(enumTypes, packTypes);
        }

        private async Task LoadAllEnumsAsync(Type[] enumTypes, Type[] packTypes)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
                var collection = await Task.Run(() =>
            {
                var allIcons = Enumerable.Empty<IIconViewModel>();
                for (var counter = 0; counter < enumTypes.Length; counter++)
                {
                    allIcons = allIcons.Concat(GetIcons(enumTypes[counter], packTypes[counter]));
                }

                return allIcons.OrderBy(i => i.Name, StringComparer.InvariantCultureIgnoreCase).ToList();
            });

                Icons = new ObservableCollection<IIconViewModel>(collection);
                IconList = new ObservableCollection<IIconViewModel>(Icons.ToList());
                IconCount = ((ICollection)Icons).Count;
                PrepareFiltering();
                SelectedIcon = Icons.First();
            });
        }

        private void PrepareFiltering()
        {
            //this._iconsCollectionView = CollectionViewSource.GetDefaultView(this.Icons);
            //this._iconsCollectionView.Filter = o => this.FilterIconsPredicate(this.FilterText, (IIconViewModel) o);
        }

        private bool FilterIconsPredicate(string filterText, IIconViewModel iconViewModel)
        {
            return string.IsNullOrWhiteSpace(filterText)
                   || iconViewModel.Name.IndexOf(filterText, StringComparison.CurrentCultureIgnoreCase) >= 0
                   || (!string.IsNullOrWhiteSpace(iconViewModel.Description) && iconViewModel.Description.IndexOf(filterText, StringComparison.CurrentCultureIgnoreCase) >= 0);
        }

        private static string GetDescription(Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attribute = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;
            return attribute != null ? attribute.Description : value.ToString();
        }

        private static IEnumerable<IIconViewModel> GetIcons(Type enumType, Type packType)
        {
            return Enum.GetValues(enumType)
                .OfType<Enum>()
                .Where(k => k.ToString() != "None")
                .Select(k => GetIconViewModel(enumType, packType, k));
        }

        private static IIconViewModel GetIconViewModel(Type enumType, Type packType, Enum k)
        {
            var description = GetDescription(k);
            return new IconViewModel()
            {
                Name = k.ToString(),
                Description = description,
                IconPackType = packType,
                IconType = enumType,
                Value = k
            };
        }

        public HomePageViewModel MainViewModel { get; }

        public string Caption { get; }

        public IEnumerable<IIconViewModel> Icons
        {
            get { return _icons; }
            set { Set(ref _icons, value); }
        }

        public ObservableCollection<IIconViewModel> IconList
        {
            get { return _iconlist; }
            set { Set(ref _iconlist, value); }
        }

        public int IconCount
        {
            get { return _iconCount; }
            set { Set(ref _iconCount, value); }
        }

        public string FilterText
        {
            get { return _filterText; }
            set
            {
                if (Set(ref _filterText, value))
                {
                    //this._iconsCollectionView.Refresh();
                }
            }
        }

        public IIconViewModel SelectedIcon
        {
            get { return _selectedIcon; }
            set { Set(ref _selectedIcon, value); }
        }
    }

    public interface IIconViewModel
    {
        string Name { get; set; }
        string Description { get; set; }
        Type IconPackType { get; set; }
        Type IconType { get; set; }
        object Value { get; set; }
    }

    public class IconViewModel : ViewModelBase, IIconViewModel
    {
        public IconViewModel()
        {
            //this.CopyToClipboard =
            //    new SimpleCommand
            //    {
            //        CanExecuteDelegate = x => (x != null),
            //        ExecuteDelegate = x => Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            //        {
            //            var icon = (IIconViewModel) x;
            //            var text = $"<iconPacks:{icon.IconPackType.Name} Kind=\"{icon.Name}\" />";
            //            Clipboard.SetDataObject(text);
            //        }))
            //    };

            //this.CopyToClipboardAsContent =
            //    new SimpleCommand
            //    {
            //        CanExecuteDelegate = x => (x != null),
            //        ExecuteDelegate = x => Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            //        {
            //            var icon = (IIconViewModel) x;
            //            var text = $"{{iconPacks:{icon.IconPackType.Name.Replace("PackIcon", "")} Kind={icon.Name}}}";
            //            Clipboard.SetDataObject(text);
            //        }))
            //    };

            //this.CopyToClipboardAsPathIcon =
            //    new SimpleCommand
            //    {
            //        CanExecuteDelegate = x => (x != null),
            //        ExecuteDelegate = x => Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            //        {
            //            var icon = (IIconViewModel) x;
            //            // The UWP type is in WPF app not available
            //            var text = $"<iconPacks:{icon.IconPackType.Name.Replace("PackIcon", "PathIcon")} Kind=\"{icon.Name}\" />";
            //            Clipboard.SetDataObject(text);
            //        }))
            //    };

            //this.CopyToClipboardAsGeometry =
            //    new SimpleCommand
            //    {
            //        CanExecuteDelegate = x => (x != null),
            //        ExecuteDelegate = x => Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            //        {
            //            var icon = (IIconViewModel)x;
            //            var iconPack = Activator.CreateInstance(icon.IconPackType) as PackIconControlBase;
            //            if (iconPack == null) return;

            //            var kindProperty = icon.IconPackType.GetProperty("Kind");
            //            if (kindProperty == null) return;

            //            kindProperty.SetValue(iconPack, icon.Value);

            //            Clipboard.SetDataObject(iconPack.Data);
            //        }))
            //    };
        }

        public ICommand CopyToClipboard { get; }

        public ICommand CopyToClipboardAsContent { get; }

        public ICommand CopyToClipboardAsPathIcon { get; }

        public ICommand CopyToClipboardAsGeometry { get; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string TypeDescription { get; set; }

        public Type IconPackType { get; set; }

        public Type IconType { get; set; }

        public object Value { get; set; }
    }
}