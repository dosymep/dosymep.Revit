using System;
using System.Runtime.InteropServices;
using System.Text;

namespace dosymep.Bim4Everyone.SimpleServices.Configuration {
    internal class IniConfigurationService {
        private readonly string _iniPath;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString,
            string lpFileName);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault,
            StringBuilder lpReturnedString, int nSize, string lpFileName);

        public IniConfigurationService(string iniPath) {
            _iniPath = iniPath;
        }
        
        public bool KeyExists(string section, string key) {
            return Read(section, key)?.Length > 0;
        }

        public int? ReadInt(string section, string key, int? @default = default) {
            if(int.TryParse(Read(section, key), out int result)) {
                return result;
            }

            return @default;
        }

        public bool? ReadBool(string section, string key, bool? @default = default) {
            if(bool.TryParse(Read(section, key), out bool result)) {
                return result;
            }

            return @default;
        }

        public TEnum? ReadEnum<TEnum>(string section, string key, TEnum? @default = default) where TEnum : struct {
            if(Enum.TryParse(Read(section, key), out TEnum result)) {
                return result;
            }

            return @default;
        }

        public string Read(string section, string key, string @default = default) {
            var retVal = new StringBuilder(255);
            GetPrivateProfileString(section, key, string.Empty, retVal, 255, _iniPath);
            return string.IsNullOrEmpty(retVal.ToString()) ? @default : retVal.ToString();
        }

        public void Write(string section, string key, string value) {
            WritePrivateProfileString(section, key, value, _iniPath);
        }

        public void RemoveSection(string section) {
            Write(section, null, null);
        }
        
        public void DeleteKey(string section, string key) {
            Write(section, key, null);
        }
    }
}