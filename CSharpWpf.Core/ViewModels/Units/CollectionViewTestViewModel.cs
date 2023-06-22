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
        [ObservableProperty]
        public ObservableCollection<Person> people;

    }
}
