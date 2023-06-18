using CommunityToolkit.Mvvm.Messaging;
using System.Windows;

namespace CSharpWpf.Core.LocalWorks.Main
{
    public class WindowCtrl
    {
        #region Method
        public void ClosingWindow(object? _UI)
        {
            Window.GetWindow(_UI as UIElement).Close();
        }

        public void MinizingWindow(object? _UI)
        {
            Window.GetWindow(_UI as UIElement).WindowState = WindowState.Minimized;
        }

        public void MaximizingWindow(object? _UI)
        {
            var _window = Window.GetWindow(_UI as UIElement);
            if (_window.WindowState == WindowState.Normal)
            {
                _window.WindowState = WindowState.Maximized;
            }
            else
            {
                _window.WindowState = WindowState.Normal;
            }
        }
        #endregion
    }
}
