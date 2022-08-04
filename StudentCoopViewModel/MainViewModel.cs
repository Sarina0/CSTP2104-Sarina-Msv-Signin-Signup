using StudentCoopCommon.Interfaces;
using StudentCoopCommon.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCoopViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public StudentViewModel StudentViewModel { get; private set; }


        public bool IsFirstNameUpdated => this.StudentViewModel.FirstName != null;

        public MainViewModel(IStudentRepository studentRepository)
        {
            if (studentRepository == null)
            {
                throw new ArgumentNullException(nameof(studentRepository));
            }

            this.StudentViewModel = new StudentViewModel(studentRepository);
        }

        public void Load()
        {
            /// var student = this.studentRepository.Get(studentIdToFatch);
            /// if (student != null)
            /// {
            ///     // this.StudentViewModel = new StudentViewModel(student, this.studentRepository);
            /// }
            /// 
            // var student2 = new Student();
            //var id2 = student2.id = 133;
            //this.studentRepository.Get(id2);
            //this.StudentViewModel = new StudentViewModel(student2+
            // , this.studentRepository);
           

        }

        public void Save()
        {
            this.StudentViewModel.Save();
            this.RaisePropertyChanged(nameof(this.StudentViewModel));
        }
        public void Login()
        {
            this.StudentViewModel.Login();
            this.RaisePropertyChanged(nameof(this.StudentViewModel));
        }
    }
}