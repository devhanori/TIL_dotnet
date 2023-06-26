using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CSharpWpf.Core.Models
{
    [XmlRoot]
    public class PeopleXml
    {
        [XmlIgnore]
        public string path = "Config\\People.xml";

        [XmlElement]
        public List<Person> peoples = new List<Person>
        {
            new Person {Name="10", Age=10},
            new Person {Name="11", Age=11},
            new Person {Name="12", Age=12},
            new Person {Name="13", Age=1},
        };

        public PeopleXml? GetPeopleAsync()
        {
            var people = new PeopleXml();

            using(var reader = new StreamReader(path))
            {
                var x = new XmlSerializer(typeof(PeopleXml));
                people = x.Deserialize(reader) as PeopleXml;
            }

            return people;
        }

        public void SetPeopleAsync(PeopleXml people)
        {
            using (var writer = new StreamWriter(path))
            {
                var x = new XmlSerializer(typeof(PeopleXml));
                x.Serialize(writer, people);
            }
                
        }
    }

    public class Person
    {
        [XmlAttribute]
        public string? Name { get; set; }
        [XmlAttribute]
        public int Age { get; set; }

    }
}
