﻿using MahAppIcons.Shared.ViewModels;
using MahAppIcons.SharedViewModels;
using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace MahAppIcons.Shared.Services
{
    class IconHelperConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                if (parameter == null)
                {
                    var icon = (IIconViewModel)value;
                    if (icon != null)
                    {
                        if (icon.IconPackType != null)
                        {
                            value = icon.IconPackType.Name;
                            return value;
                        }
                    }
                }
                else if (parameter.ToString() == "ItemDetail")
                {
                    var icon1 = (IIconViewModel)value;
                    if (icon1 != null)
                    {
                        var iconPack = Activator.CreateInstance(icon1.IconPackType) as PackIconControlBase;
                        if (iconPack != null)
                        {
                            value = icon1.IconPackType.Name;
                            return value;
                        }
                    }
                }
            }
            return value;

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
