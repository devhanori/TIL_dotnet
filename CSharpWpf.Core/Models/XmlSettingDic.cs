using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CSharpWpf.Core.Models
{
    [XmlRoot]
    public class XmlSettingDic
    {
        [XmlIgnore]
        public string path = "Config\\Setting.xml";

        [XmlElement]
        public Dictionary<string, object> SettingsStorage;
        public XmlSettingDic() { }
        public XmlSettingDic? Get()
        {
            var xmlsetting = new XmlSettingDic();

            using (var reader = new StreamReader(path))
            {
                var x = new XmlSerializer(typeof(XmlSettingDic));
                xmlsetting = x.Deserialize(reader) as XmlSettingDic;
            }

            return xmlsetting;
        }

        public void Set(XmlSettingDic xmlsetting)
        {
            using (var writer = new StreamWriter(path))
            {
                var x = new XmlSerializer(typeof(XmlSettingDic));
                x.Serialize(writer, xmlsetting);
            }
        }

    }
}
