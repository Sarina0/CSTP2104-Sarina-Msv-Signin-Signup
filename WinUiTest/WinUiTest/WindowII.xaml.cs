using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;



using StudentCoopCommon.Interfaces;
using StudentCoopDal;
using StudentCoopViewModel;
using msWindowActivated = Microsoft.UI.Xaml;
namespace WinUiTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WindowII : Page
    {
        //public event EventHandler Activated;
        public event TypedEventHandler<object, WindowActivatedEventArgs> Activated2;
        public MainViewModel mainViewModel { get; }
        public WindowII()
        {
            this.InitializeComponent();
           
        IStudentRepository studentRepository = new StudentRepositoryFactory().Create(StudentRepositoryType.InMemoryStudentRepository);

            this.mainViewModel = new MainViewModel(studentRepository);
            
            this.Activated2 += this.MainWindowII_Activated;
           
        }
        private void MainWindowII_Activated(object sender, msWindowActivated.WindowActivatedEventArgs args)
        {

            //this.mainViewModel.SignUp();
            if (!this.mainViewModel.Students.Any())
            {
                this.mainViewModel.PopulateStudentList();
            }

        }
        private void navigateButton_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = this.Content as Frame;

            if (rootFrame == null)
            {
                rootFrame = new Frame();
                this.Content = rootFrame;
            }

            /// example without passing data
            /// rootFrame.Navigate(typeof(MyBlankPage));

            /// example with passing data
            //rootFrame.Navigate(typeof(Window31), "passedID123");
        }
        private void Button_SignUp(object sender, RoutedEventArgs e)
        {

            //greetingOutput.Text = "unsuccessful";


        }
    }

}
