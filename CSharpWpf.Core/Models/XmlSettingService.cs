using CSharpWpf.Core.Services;

namespace CSharpWpf.Core.Models
{
    public class XmlSettingService : IXmlSettingService
    {
        private XmlSettingDic XmlSettingDic { get; set; } = new();
        public T? GetValue<T>(string key)
        {
            XmlSettingDic = XmlSettingDic.Get();
            if (XmlSettingDic.SettingsStorage.TryGetValue(key, out object? value))
            {
                return (T)value;
            }
            return default;
        }

        public void SetValue<T>(string key, T? value)
        {
            if (!XmlSettingDic.SettingsStorage.ContainsKey(key)) XmlSettingDic.SettingsStorage.Add(key, value);
            else XmlSettingDic.SettingsStorage[key] = value;
            XmlSettingDic.Set(XmlSettingDic);
        }
    }
}
