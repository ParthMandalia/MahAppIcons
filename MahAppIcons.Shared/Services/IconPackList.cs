using GalaSoft.MvvmLight;
using MahAppIcons.Shared.ViewModels;
using MahAppIcons.SharedViewModels;
using MahApps.Metro.IconPacks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace MahAppIcons.Shared.Services
{
    public class IconPackList
    {

        public static async Task<ObservableCollection<IconPackViewModel>> CreateIconPackList(HomePageViewModel vm, ObservableCollection<IconPackViewModel> collection = null)
        {
            collection = new ObservableCollection<IconPackViewModel>(
            new[]
            {
                     new IconPackViewModel(vm,"All",
                        new[]
                        {
                            typeof(PackIconBoxIconsKind),
                            typeof(PackIconEntypoKind),
                            typeof(PackIconEvaIconsKind),
                            typeof(PackIconFeatherIconsKind),
                            typeof(PackIconFontAwesomeKind),
                            typeof(PackIconIoniconsKind),
                            typeof(PackIconJamIconsKind),
                            typeof(PackIconMaterialKind),
                            typeof(PackIconMaterialDesignKind),
                            typeof(PackIconMaterialLightKind),
                            typeof(PackIconMicronsKind),
                            typeof(PackIconModernKind),
                            typeof(PackIconOcticonsKind),
                            typeof(PackIconPicolIconsKind),
                            typeof(PackIconRPGAwesomeKind),
                            typeof(PackIconSimpleIconsKind),
                            typeof(PackIconTypiconsKind),
                            typeof(PackIconUniconsKind),
                            typeof(PackIconWeatherIconsKind),
                            typeof(PackIconZondiconsKind)
                        },
                        new[]
                        {
                            typeof(PackIconBoxIcons),
                            typeof(PackIconEntypo),
                            typeof(PackIconEvaIcons),
                            typeof(PackIconFeatherIcons),
                            typeof(PackIconFontAwesome),
                            typeof(PackIconIonicons),
                            typeof(PackIconJamIcons),
                            typeof(PackIconMaterial),
                            typeof(PackIconMaterialDesign),
                            typeof(PackIconMaterialLight),
                            typeof(PackIconMicrons),
                            typeof(PackIconModern),
                            typeof(PackIconOcticons),
                            typeof(PackIconPicolIcons),
                            typeof(PackIconRPGAwesome),
                            typeof(PackIconSimpleIcons),
                            typeof(PackIconTypicons),
                            typeof(PackIconUnicons),
                            typeof(PackIconWeatherIcons),
                            typeof(PackIconZondicons)
                        }),
                    new IconPackViewModel(vm,"BoxIcons", typeof(PackIconBoxIconsKind), typeof(PackIconBoxIcons)),
                    new IconPackViewModel(vm,"Entypo+", typeof(PackIconEntypoKind), typeof(PackIconEntypo)),
                    new IconPackViewModel(vm,"EvaIcons", typeof(PackIconEvaIconsKind), typeof(PackIconEvaIcons)),
                    new IconPackViewModel(vm,"FeatherIcons", typeof(PackIconFeatherIconsKind), typeof(PackIconFeatherIcons)),
                    new IconPackViewModel(vm,"FontAwesome", typeof(PackIconFontAwesomeKind), typeof(PackIconFontAwesome)),
                    new IconPackViewModel(vm,"Ionicons", typeof(PackIconIoniconsKind), typeof(PackIconIonicons)),
                    new IconPackViewModel(vm,"JamIcons", typeof(PackIconJamIconsKind), typeof(PackIconJamIcons)),
                    new IconPackViewModel(vm,"Material", typeof(PackIconMaterialKind), typeof(PackIconMaterial)),
                    new IconPackViewModel(vm,"MaterialDesign (Google)", typeof(PackIconMaterialDesignKind), typeof(PackIconMaterialDesign)),
                    new IconPackViewModel(vm,"MaterialLight", typeof(PackIconMaterialLightKind), typeof(PackIconMaterialLight)),
                    new IconPackViewModel(vm,"Microns", typeof(PackIconMicronsKind), typeof(PackIconMicrons)),
                    new IconPackViewModel(vm,"Modern", typeof(PackIconModernKind), typeof(PackIconModern)),
                    new IconPackViewModel(vm,"Octicons", typeof(PackIconOcticonsKind), typeof(PackIconOcticons)),
                    new IconPackViewModel(vm,"PICOL", typeof(PackIconPicolIconsKind), typeof(PackIconPicolIcons)),
                    new IconPackViewModel(vm,"RPGAwesome", typeof(PackIconRPGAwesomeKind), typeof(PackIconRPGAwesome)),
                    new IconPackViewModel(vm,"SimpleIcons", typeof(PackIconSimpleIconsKind), typeof(PackIconSimpleIcons)),
                    new IconPackViewModel(vm,"Typicons", typeof(PackIconTypiconsKind), typeof(PackIconTypicons)),
                    new IconPackViewModel(vm,"Unicons", typeof(PackIconUniconsKind), typeof(PackIconUnicons)),
                    new IconPackViewModel(vm,"WeatherIcons", typeof(PackIconWeatherIconsKind), typeof(PackIconWeatherIcons)),
                    new IconPackViewModel(vm,"Zondicons", typeof(PackIconZondiconsKind), typeof(PackIconZondicons))
            });
            return await Task.FromResult(collection);
        }

        public static string GetPathIconFromIconPack(Type enumType, Type packType, Enum k)
        {
            try
            {
                string data = string.Empty;
                if (enumType.Name == "PackIconBoxIconsKind")
                {
                    PackIconBoxIconsDataFactory.DataIndex.Value?.TryGetValue((PackIconBoxIconsKind)k, out data);
                    return data;
                }
                if (enumType.Name == "PackIconEntypoKind")
                {
                    PackIconEntypoDataFactory.DataIndex.Value?.TryGetValue((PackIconEntypoKind)k, out data);
                    return data;
                }
                if (enumType.Name == "PackIconEvaIconsKind")
                {
                    PackIconEvaIconsDataFactory.DataIndex.Value?.TryGetValue((PackIconEvaIconsKind)k, out data);
                    return data;
                }
                if (enumType.Name == "PackIconFeatherIconsKind")
                {
                    PackIconFeatherIconsDataFactory.DataIndex.Value?.TryGetValue((PackIconFeatherIconsKind)k, out data);
                    return data;
                }
                if (enumType.Name == "PackIconFontAwesomeKind")
                {
                    PackIconFontAwesomeDataFactory.DataIndex.Value?.TryGetValue((PackIconFontAwesomeKind)k, out data);
                    return data;
                }
                if (enumType.Name == "PackIconIoniconsKind")
                {
                    PackIconIoniconsDataFactory.DataIndex.Value?.TryGetValue((PackIconIoniconsKind)k, out data);
                    return data;
                }
                if (enumType.Name == "PackIconJamIconsKind")
                {
                    PackIconJamIconsDataFactory.DataIndex.Value?.TryGetValue((PackIconJamIconsKind)k, out data);
                    return data;
                }
                //if (this.Kind is PackIconMaterialKind)
                //{
                //    return this.GetPackIcon<PackIconMaterial, PackIconMaterialKind>((PackIconMaterialKind)this.Kind);
                //}
                //if (this.Kind is PackIconMaterialDesignKind)
                //{
                //    return this.GetPackIcon<PackIconMaterialDesign, PackIconMaterialDesignKind>((PackIconMaterialDesignKind)this.Kind);
                //}
                //if (this.Kind is PackIconMaterialLightKind)
                //{
                //    return this.GetPackIcon<PackIconMaterialLight, PackIconMaterialLightKind>((PackIconMaterialLightKind)this.Kind);
                //}
                //if (this.Kind is PackIconMicronsKind)
                //{
                //    return this.GetPackIcon<PackIconMicrons, PackIconMicronsKind>((PackIconMicronsKind)this.Kind);
                //}
                //if (this.Kind is PackIconModernKind)
                //{
                //    return this.GetPackIcon<PackIconModern, PackIconModernKind>((PackIconModernKind)this.Kind);
                //}
                //if (this.Kind is PackIconOcticonsKind)
                //{
                //    return this.GetPackIcon<PackIconOcticons, PackIconOcticonsKind>((PackIconOcticonsKind)this.Kind);
                //}
                //if (this.Kind is PackIconPicolIconsKind)
                //{
                //    return this.GetPackIcon<PackIconPicolIcons, PackIconPicolIconsKind>((PackIconPicolIconsKind)this.Kind);
                //}
                //if (this.Kind is PackIconRPGAwesomeKind)
                //{
                //    return this.GetPackIcon<PackIconRPGAwesome, PackIconRPGAwesomeKind>((PackIconRPGAwesomeKind)this.Kind);
                //}
                //if (this.Kind is PackIconSimpleIconsKind)
                //{
                //    return this.GetPackIcon<PackIconSimpleIcons, PackIconSimpleIconsKind>((PackIconSimpleIconsKind)this.Kind);
                //}
                //if (this.Kind is PackIconTypiconsKind)
                //{
                //    return this.GetPackIcon<PackIconTypicons, PackIconTypiconsKind>((PackIconTypiconsKind)this.Kind);
                //}
                //if (this.Kind is PackIconUniconsKind)
                //{
                //    return this.GetPackIcon<PackIconUnicons, PackIconUniconsKind>((PackIconUniconsKind)this.Kind);
                //}
                //if (this.Kind is PackIconWeatherIconsKind)
                //{
                //    return this.GetPackIcon<PackIconWeatherIcons, PackIconWeatherIconsKind>((PackIconWeatherIconsKind)this.Kind);
                //}
                //if (this.Kind is PackIconZondiconsKind)
                //{
                //    return this.GetPackIcon<PackIconZondicons, PackIconZondiconsKind>((PackIconZondiconsKind)this.Kind);
                //}
                return data;
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
