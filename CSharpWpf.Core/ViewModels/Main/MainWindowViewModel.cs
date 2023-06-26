using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CSharpWpf.Core.Messages;
using CSharpWpf.Core.LocalWorks.Main;
using CSharpWpf.Core.Services;
using CSharpWpf.Core.Models;

namespace CSharpWpf.Core.ViewModels.Main
{
    public partial class MainWindowViewModel : ObservableObject
    {
        #region Initialize
        private System.Threading.Timer? DateTimeTimer;
        private WindowCtrl? WinCtrl = new();
        private readonly IEnumerable<IMenuView>? MenuViews;
        PeopleXmlService peopleService;
        public MainWindowViewModel(
            IEnumerable<IMenuView> _meunViews,
            PeopleXmlService _peopleService)
        {
            MenuViews = _meunViews.ToList();
            peopleService = _peopleService;

            Initialize();
        }

        private void Initialize()
        {
            MenuViewEnable = false;
            DateTimeTimer = new System.Threading.Timer(OnDTUpdate, null, 1000, 500);

            // 초기 화면 Setting
            CurrentView = MenuViews?.FirstOrDefault(c => c.Name == "CollectionView");
            currentViewName = "CollectionView";

            Assembly assembly = Assembly.GetExecutingAssembly();
            DateTime buildDate = System.IO.File.GetLastWriteTime(assembly.Location);
        }
        #endregion

        #region Method
        
        private void OnDTUpdate(object? state)
        {
            var strTemp = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            CurrentDateTimeText = strTemp;
        }
        #endregion Method

        private string? currentViewName { get; set; }

        #region [ObservableProperty]
        [ObservableProperty]
        private string? currentDateTimeText;
        [ObservableProperty]
        private bool menuViewEnable;
        [ObservableProperty]
        private object? currentView;
        #endregion [ObservableProperty]

        #region [RelayCommand]
        [RelayCommand]
        private void MainExit(object? value)
        {
            WinCtrl?.ClosingWindow(value);
            WeakReferenceMessenger.Default.Send(new ProgramExitMessage(true));
        }
        [RelayCommand]
        private void MainMini(object? value)
        {
            WinCtrl?.MinizingWindow(value);
        }
        [RelayCommand]
        private void MainMax(object? value)
        {
            WinCtrl?.MaximizingWindow(value);
        }
        [RelayCommand]
        private void MenuChange(string? value)
        {
            if (value != null)
            {
                CurrentView = null;
                CurrentView = MenuViews?.FirstOrDefault(c => c.Name == value);
            }
            currentViewName = new string(value);
        }
        #endregion [RelayCommand]
    }
}