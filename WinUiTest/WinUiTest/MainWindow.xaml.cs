using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Linq;
using StudentCoopCommon.Interfaces;
using StudentCoopDal;
using StudentCoopViewModel;
using msWindowActivated = Microsoft.UI.Xaml;
using System;

namespace WinUiTest
{

    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel mainViewModel { get; }


        public MainWindow()
        {
            this.InitializeComponent();

            IStudentRepository studentRepository = new StudentRepositoryFactory().Create(StudentRepositoryType.InMemoryStudentRepository);

            this.mainViewModel = new MainViewModel(studentRepository);

            this.Activated += this.MainWindow_Activated;
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


            // rootFrame.Navigate(typeof(Update), "passedID123");
            int some2 = this.mainViewModel.Get_ID();


            try
            {


                if (some2 == 1)
                {
                    //greetingOutput.Text = "Successful";
                    Frame rootFrame = this.Content as Frame;

                    if (rootFrame == null)
                    {
                        rootFrame = new Frame();
                        this.Content = rootFrame;
                    }

                    rootFrame.Navigate(typeof(UpdatePage));

                }
                else
                {
                    greetingOutput.Text = "Unsuccessful";
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Catch Block = " + ex);
            }
            finally
            {


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
            rootFrame.Navigate(typeof(WindowII), "passedID123");
        }


    }


}


