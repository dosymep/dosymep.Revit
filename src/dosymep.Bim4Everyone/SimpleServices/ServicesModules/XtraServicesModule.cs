using System;
using System.Globalization;
using System.IO;
using System.Net.Cache;
using System.Reflection;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

using Autodesk.Revit.UI;

using DevExpress.Mvvm.UI;

using dosymep.Bim4Everyone.SimpleServices.Configuration;
using dosymep.Bim4Everyone.SimpleServices.NullServices;
using dosymep.SimpleServices;
using dosymep.Xpf.Core.Ninject;
using dosymep.Xpf.Core.SimpleServices;

using Ninject;
using Ninject.Activation;
using Ninject.Modules;

namespace dosymep.Bim4Everyone.SimpleServices.ServicesModules {
    internal class XtraServicesModule : NinjectModule {
        public override void Load() {
#if REVIT2024_OR_GREATER
            Bind<IUIThemeService>()
                .To<RevitThemeService>()
                .InSingletonScope();
#else
            Kernel?.UseXtraTheme();
#endif
            Kernel?.UseXtraMessageBox();
            Kernel?.UseXtraThemeUpdater();
            Kernel?.UseXtraProgressDialog();

            IPlatformSettingsService settingsService = Kernel?.Get<IPlatformSettingsService>();
            
            CorpSettings corpSettings = settingsService?.CorpSettings;
            NotificationSettings notificationSettings = settingsService?.NotificationSettings;

            if(notificationSettings?.IsActive == false) {
                Bind<INotificationService>().To<NullNotificationService>();
            } else {
                BitmapImage defaultImage = new BitmapImage(
                    new Uri("/dosymep.Bim4Everyone;component/assets/Bim4Everyone.png", UriKind.Relative));

                if(!string.IsNullOrEmpty(corpSettings?.ImagePath)) {
                    if(File.Exists(corpSettings.ImagePath)
                        || Uri.TryCreate(corpSettings.ImagePath, UriKind.Absolute, out Uri _)) {
                        defaultImage = new BitmapImage(new Uri(corpSettings.ImagePath, UriKind.RelativeOrAbsolute));
                    }
                }

                Kernel?.UseXtraNotifications(
                    defaultImage: defaultImage,
                    applicationId: "Revit " + ModuleEnvironment.RevitVersion,
                    defaultAuthor: "dosymep",
                    defaultFooter: "Revit " + ModuleEnvironment.RevitVersion,
                    notificationScreen: notificationSettings?.NotificationScreen ?? NotificationScreen.Primary,
                    notificationPosition: notificationSettings?.NotificationPosition ?? NotificationPosition.BottomRight,
                    notificationVisibleMaxCount: notificationSettings?.NotificationVisibleMaxCount ?? 5);
            }

            Kernel?.UseXtraOpenFileDialog(
                initialDirectory: Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

            Kernel?.UseXtraSaveFileDialog(
                initialDirectory: Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

            Kernel?.UseXtraOpenFolderDialog(
                initialDirectory: Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            
            Kernel?.UseXtraLocalization(
                $"/dosymep.Bim4Everyone;component/Localization/Language.xaml",
                CultureInfo.GetCultureInfo("ru-RU"));
        }
    }
}