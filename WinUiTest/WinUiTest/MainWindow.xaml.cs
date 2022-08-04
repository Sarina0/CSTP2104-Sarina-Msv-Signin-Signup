using ABI.Microsoft.UI;
using ABI.Microsoft.UI.Xaml.Shapes;
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

using StudentCoopCommon;
using StudentCoopCommon.Interfaces;
using StudentCoopCommon.Logging;
using StudentCoopCommon.ViewModels;
using System.Windows;
using StudentCoopDal;


using StudentCoopViewModel;



using Windows.UI.Core;

using msWindowActivated = Microsoft.UI.Xaml;
using System.ComponentModel.DataAnnotations;



// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUiTest
{


    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel mainViewModel { get; }

        [Required(ErrorMessage = "first name is required")]
        public int First { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public int Last { get; set; }

        public MainWindow()
        {
            this.InitializeComponent();

            IStudentRepository studentRepository = new StudentRepositoryFactory().Create(StudentRepositoryType.InMemoryStudentRepository);

            this.mainViewModel = new MainViewModel(studentRepository);

            this.Activated += this.MainWindow_Activated;
        }
        private void MainWindow_Activated(object sender, msWindowActivated.WindowActivatedEventArgs args)
        {


                this.mainViewModel.Save();
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            //greetingOutput.Text = "unsuccessful";
         

        }
       



    }
       

    }


