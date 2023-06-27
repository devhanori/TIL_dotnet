using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpWpf.Core.Services
{
    public interface IXmlSettingService
    {
        void SetValue<T>(string key, T? value);
        T? GetValue<T>(string key);
    }
}
