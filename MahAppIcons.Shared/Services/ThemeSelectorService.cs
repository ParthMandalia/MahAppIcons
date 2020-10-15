using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace MahAppIcons.Shared.Services
{
    public static class ThemeSelectorService
    {
        private const string SettingsKey = "AppBackgroundRequestedTheme";

        public static ElementTheme Theme { get; set; } = ElementTheme.Default;

        public static void InitializeAsync()
        {
            Theme = LoadThemeFromSettingsAsync();
        }

        public static async Task SetThemeAsync(ElementTheme theme)
        {
            Theme = theme;

            await SetRequestedThemeAsync();
            SaveThemeInSettingsAsync(Theme);
        }

        public static async Task SetRequestedThemeAsync()
        {
            foreach (var view in CoreApplication.Views)
            {
                await view.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    if (Window.Current.Content is FrameworkElement frameworkElement)
                    {
                        frameworkElement.RequestedTheme = Theme;
                    }
                });
            }
        }

        private static ElementTheme LoadThemeFromSettingsAsync()
        {
            ElementTheme cacheTheme = ElementTheme.Default;
            //string themeName = await ApplicationData.Current.LocalSettings.ReadAsync<string>(SettingsKey);
            object themeName;
            ApplicationData.Current.LocalSettings.Values.TryGetValue(SettingsKey, out themeName);
            if (!string.IsNullOrEmpty(themeName.ToString()))
            {
                Enum.TryParse(themeName.ToString(), out cacheTheme);
            }

            return cacheTheme;
        }

        private static void SaveThemeInSettingsAsync(ElementTheme theme)
        {
            ApplicationData.Current.LocalSettings.SaveString(SettingsKey, theme.ToString());
        }
    }
}
