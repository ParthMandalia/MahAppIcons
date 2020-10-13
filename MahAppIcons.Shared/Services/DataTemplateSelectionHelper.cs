using MahAppIcons.SharedViewModels;
using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace MahAppIcons.Shared.Services
{
    public class DataTemplateSelectionHelper : DataTemplateSelector
    {
        public DataTemplate General { get; set; }
        public DataTemplate BoxIcons { get; set; }
        public DataTemplate Entypo { get; set; }
        public DataTemplate EvaIcons { get; set; }
        public DataTemplate FeatherIcons { get; set; }
        public DataTemplate FontAwesome { get; set; }
        public DataTemplate Ionicons { get; set; }
        public DataTemplate JamIcons { get; set; }
        public DataTemplate Material { get; set; }
        public DataTemplate MaterialDesign { get; set; }
        public DataTemplate MaterialLight { get; set; }
        public DataTemplate Microns { get; set; }
        public DataTemplate Modern { get; set; }
        public DataTemplate Octicons { get; set; }
        public DataTemplate PICOL { get; set; }
        public DataTemplate RPGAwesome { get; set; }
        public DataTemplate SimpleIcons { get; set; }
        public DataTemplate Typicons { get; set; }
        public DataTemplate Unicons { get; set; }
        public DataTemplate WeatherIcons { get; set; }
        public DataTemplate Zondicons { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item != null)
            {
                var result = (IIconViewModel)item;
                var iconPack = Activator.CreateInstance(result.IconPackType) as PackIconControlBase;
                var iconname = iconPack.GetType();
                if (iconPack != null)
                {
                    if (iconname.Name == "PackIconBoxIcons")
                    {
                        return BoxIcons;
                    }
                    else if (iconname.Name == "PackIconEntypo")
                    {
                        return Entypo;
                    }
                    else if (iconname.Name == "PackIconEvaIcons")
                    {
                        return Entypo;
                    }
                    else
                    {
                        return General;
                    }
                }
            }
            return General;
        }
    }
}
