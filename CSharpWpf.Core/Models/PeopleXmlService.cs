using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharpWpf.Core.Models
{
    public class PeopleXmlService
    {
        public PeopleXml people { get; set; } = new PeopleXml();
        public PeopleXmlService()
        {
            people.SetPeopleAsync(new PeopleXml());
        }
    }

}
