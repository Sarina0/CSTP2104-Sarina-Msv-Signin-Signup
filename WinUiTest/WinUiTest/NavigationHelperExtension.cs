using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUiTest
{

    public static class NavigationHelperExtension
    {
        public static void Navigate(Type typeOfPage)
        {
            Microsoft.UI.Xaml.Window window = Microsoft.UI.Xaml.Window.Current;
            if (window != null)
            {
                Microsoft.UI.Xaml.Controls.Frame frame = window.Content as Microsoft.UI.Xaml.Controls.Frame;
                if (frame != null)
                {
                    frame.Navigate(typeOfPage);
                }
            }
        }

        public static void Navigate(Type typeOfPage, object param)
        {
            Microsoft.UI.Xaml.Window window = Microsoft.UI.Xaml.Window.Current;
            if (window != null)
            {
                Microsoft.UI.Xaml.Controls.Frame frame = window.Content as Microsoft.UI.Xaml.Controls.Frame;
                if (frame != null)
                {
                    frame.Navigate(typeOfPage, param);
                }
            }
        }

    }
}
