using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpWpf.Core.Models;

namespace CSharpWpf.Core.ViewModels.Units
{
    public partial class CollectionViewTestViewModel : ObservableObject
    {
        private readonly PeopleXmlService peopleService;
        public CollectionViewTestViewModel(
            PeopleXmlService _peopleService) 
        {
            peopleService = _peopleService;
            People = new ObservableCollection<Person>(peopleService.people.peoples);
        }

        [ObservableProperty]
        public ObservableCollection<Person> people;


    }
}
