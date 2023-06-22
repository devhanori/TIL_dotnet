using CSharpWpf.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharpWpf.Core.Services
{
    public class PeopleService
    {
        public People people { get; set; } = new People();
        public PeopleService() 
        {
            people.SetPeopleAsync(new People());
            var test = new People().GetPeopleAsync();
            people = test;
        }
    }

}
