using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CSharpWpf.Core.Models
{
    [XmlRoot]
    public class People
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

        public People? GetPeopleAsync()
        {
            var people = new People();

            using(var reader = new StreamReader(path))
            {
                var x = new XmlSerializer(typeof(People));
                people = x.Deserialize(reader) as People;
            }

            return people;
        }

        public void SetPeopleAsync(People people)
        {
            using (var writer = new StreamWriter(path))
            {
                var x = new XmlSerializer(typeof(People));
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
