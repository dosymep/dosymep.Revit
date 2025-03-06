using System;
using System.Globalization;

using Autodesk.Revit.ApplicationServices;

using dosymep.SimpleServices;

namespace dosymep.Bim4Everyone.SimpleServices {
    internal class RevitLanguageService : ILanguageService {
        public event Action<CultureInfo> LanguageChanged;
        
        private readonly Application _application;

        public RevitLanguageService(Application application) {
            _application = application;
        }

        public CultureInfo HostLanguage => GetCultureInfo();

        private CultureInfo GetCultureInfo() {
            switch(_application.Language) {
                case LanguageType.Unknown:
                    return CultureInfo.InvariantCulture;
                case LanguageType.English_USA:
                    return CultureInfo.GetCultureInfo("en-US");
                case LanguageType.German:
                    return CultureInfo.GetCultureInfo("de-DE");
                case LanguageType.Spanish:
                    return CultureInfo.GetCultureInfo("es-ES");
                case LanguageType.French:
                    return CultureInfo.GetCultureInfo("fr-FR");
                case LanguageType.Italian:
                    return CultureInfo.GetCultureInfo("it-IT");
                case LanguageType.Dutch:
                    return CultureInfo.GetCultureInfo("nl-NL");
                case LanguageType.Chinese_Simplified:
                    return CultureInfo.GetCultureInfo("zh-CHS");
                case LanguageType.Chinese_Traditional:
                    return CultureInfo.GetCultureInfo("zh-CHT");
                case LanguageType.Japanese:
                    return CultureInfo.GetCultureInfo("ja-JP");
                case LanguageType.Korean:
                    return CultureInfo.GetCultureInfo("ko-KR");
                case LanguageType.Russian:
                    return CultureInfo.GetCultureInfo("ru-RU");
                case LanguageType.Czech:
                    return CultureInfo.GetCultureInfo("cs-CZ");
                case LanguageType.Polish:
                    return CultureInfo.GetCultureInfo("pl-PL");
                case LanguageType.Hungarian:
                    return CultureInfo.GetCultureInfo("hu-HU");
                case LanguageType.Brazilian_Portuguese:
                    return CultureInfo.GetCultureInfo("pt-BR");
                case LanguageType.English_GB:
                    return CultureInfo.GetCultureInfo("en-GB");
                default:
                    throw new NotSupportedException($"Язык \"{_application.Language}\" не поддерживается.");
            }
        }
    }
}