using GalaSoft.MvvmLight;
using MahAppIcons.Shared.ViewModels;
using MahAppIcons.SharedViewModels;
using MahApps.Metro.IconPacks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace MahAppIcons.Shared.Services
{
    public class IconPackList
    {
        
        public static async Task<ObservableCollection<IconPackViewModel>> CreateIconPackList(HomePageViewModel vm, ObservableCollection<IconPackViewModel> collection = null)
        {
                 collection = new ObservableCollection<IconPackViewModel>(
                 new[]
                 {
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
                    //new IconPackViewModel(vm,"All",
                    //    new[]
                    //    {
                    //        typeof(PackIconBoxIconsKind),
                    //        typeof(PackIconEntypoKind),
                    //        typeof(PackIconEvaIconsKind),
                    //        typeof(PackIconFeatherIconsKind),
                    //        typeof(PackIconFontAwesomeKind),
                    //        typeof(PackIconIoniconsKind),
                    //        typeof(PackIconJamIconsKind),
                    //        typeof(PackIconMaterialKind),
                    //        typeof(PackIconMaterialDesignKind),
                    //        typeof(PackIconMaterialLightKind),
                    //        typeof(PackIconMicronsKind),
                    //        typeof(PackIconModernKind),
                    //        typeof(PackIconOcticonsKind),
                    //        typeof(PackIconPicolIconsKind),
                    //        typeof(PackIconRPGAwesomeKind),
                    //        typeof(PackIconSimpleIconsKind),
                    //        typeof(PackIconTypiconsKind),
                    //        typeof(PackIconUniconsKind),
                    //        typeof(PackIconWeatherIconsKind),
                    //        typeof(PackIconZondiconsKind)
                    //    },
                    //    new[]
                    //    {
                    //        typeof(PackIconBoxIcons),
                    //        typeof(PackIconEntypo),
                    //        typeof(PackIconEvaIcons),
                    //        typeof(PackIconFeatherIcons),
                    //        typeof(PackIconFontAwesome),
                    //        typeof(PackIconIonicons),
                    //        typeof(PackIconJamIcons),
                    //        typeof(PackIconMaterial),
                    //        typeof(PackIconMaterialDesign),
                    //        typeof(PackIconMaterialLight),
                    //        typeof(PackIconMicrons),
                    //        typeof(PackIconModern),
                    //        typeof(PackIconOcticons),
                    //        typeof(PackIconPicolIcons),
                    //        typeof(PackIconRPGAwesome),
                    //        typeof(PackIconSimpleIcons),
                    //        typeof(PackIconTypicons),
                    //        typeof(PackIconUnicons),
                    //        typeof(PackIconWeatherIcons),
                    //        typeof(PackIconZondicons)
                    //    })
                 });
            return await Task.FromResult(collection);
        }

    }

}
