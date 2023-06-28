using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpWpf.Core.Models;
using CSharpWpf.Core.Services;

namespace CSharpWpf.Core.ViewModels.Units
{
    public partial class CollectionViewTestViewModel : ObservableObject
    {
        private readonly PeopleXmlService peopleService;
        private readonly IXmlSettingService xmlSettingService;
        public CollectionViewTestViewModel(
            PeopleXmlService _peopleService,
            IXmlSettingService _xmlSettingService) 
        {
            xmlSettingService = _xmlSettingService;
            peopleService = _peopleService;
            People = new ObservableCollection<Person>(peopleService.people.peoples);

            xmlSettingService.SetValue<int>("good", 1);
            var test = xmlSettingService.GetValue<string>("good");


        }

        [ObservableProperty]
        public ObservableCollection<Person> people;


    }
}
