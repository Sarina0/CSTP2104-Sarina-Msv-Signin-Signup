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
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUiTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UpdatePage : Page
    {
        
        public MainViewModel mainViewModel { get; }
        public event TypedEventHandler<object, WindowActivatedEventArgs> Activated3;
        public UpdatePage()
        {
            this.InitializeComponent();

            IStudentRepository studentRepository = new StudentRepositoryFactory().Create(StudentRepositoryType.InMemoryStudentRepository);

            this.mainViewModel = new MainViewModel(studentRepository);

            this.Activated3 += this.MainWindow_Activated;
        }
        private void MainWindow_Activated(object sender, msWindowActivated.WindowActivatedEventArgs args)
        {

            // this.mainViewModel.Save();
            if (!this.mainViewModel.Students.Any())
            {
                this.mainViewModel.PopulateStudentList();
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
 }
