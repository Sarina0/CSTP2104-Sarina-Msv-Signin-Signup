using ABI.Microsoft.UI;
using ABI.Microsoft.UI.Xaml.Shapes;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using StudentCoopApp;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using StudentCoopBL;
using StudentCoopCommon;
using StudentCoopCommon.Interfaces;
using StudentCoopCommon.Logging;
using StudentCoopCommon.ViewModels;

using StudentCoopDal;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUiTest
{


    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
      


        public MainWindow()
        {
            this.InitializeComponent();
           

        }
        
       
        
        public class StudentManagerTest {
            private ILogger logger;
            public delegate void printString(string s);
            private StudentManager studentManager;
            private readonly StudentRepositoryFactory studentRepositoryFactory = new StudentRepositoryFactory();

            private void InitializeTest()
            {
                this.logger = new FileLogger();
                this.studentManager = new StudentManager(
                    studentRepositoryFactory.Create(StudentRepositoryType.InMemoryStudentRepository),
                    logger);
            }
            public void GetStudents()
            {
                InitializeTest();
                studentManager.GetAllStudent();
            }
            public string ThisIsTest()
            {
                var  test= "hi test";
                return test;
            }
            public void Get_This_StudentBy_id()
            {
                InitializeTest();
                studentManager.GetById();
                

            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           //var studentManagerTest = new StudentManagerTest();
        
            //studentManagerTest.Get_This_StudentBy_id();
            greetingOutput.Text = "Helotest";
            

        }
       

    }

}
