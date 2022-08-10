using StudentCoopCommon.Interfaces;
using StudentCoopCommon.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;


using System.Collections.ObjectModel;


namespace StudentCoopViewModel
{
    public class MainViewModel : ViewModelBase
    {


        private readonly IStudentRepository studentRepository;

        private StudentViewModel studentViewModel;

        public StudentViewModel StudentViewModel
        {
            get
            {
                return this.studentViewModel;
            }

            set
            {
                if (value != null)
                {
                    this.studentViewModel = value;
                    this.RaisePropertyChanged(nameof(this.StudentViewModel));
                }
            }
        }

        public ObservableCollection<StudentViewModel> Students { get; private set; }

        public StudentViewModel SelectedStudentViewModel { get; set; }

        public MainViewModel(IStudentRepository studentRepository)
        {
            if (studentRepository == null)
            {
                throw new ArgumentNullException(nameof(studentRepository));
            }

            this.Students = new ObservableCollection<StudentViewModel>();
            this.studentRepository = studentRepository;
            this.InitializeStudentViewModel();
        }

        public void PopulateStudentList()
        {
            var students = this.studentRepository.Get();

            foreach (var student in students)
            {
                var studentViewModel = new StudentViewModel(this.studentRepository)
                {
                    ID = student.id,
                    FirstName = student.first,
                    LastName = student.last
                };
                this.Students.Add(studentViewModel);
            }
        }

        public void Save()
        {
            this.StudentViewModel.Save();

            this.Students.Clear();
            this.PopulateStudentList();

            this.RaisePropertyChanged(nameof(this.StudentViewModel));
        }

        public void Login()
        {
            this.StudentViewModel.Login();
            this.RaisePropertyChanged(nameof(this.StudentViewModel));
        }
        public void InitializeStudentViewModel()
        {
            this.StudentViewModel = new StudentViewModel(this.studentRepository);
            this.SelectedStudentViewModel = new StudentViewModel(this.studentRepository);
        }
        public void SignUp()
        {
            this.studentViewModel.Add();
            this.Students.Clear();
            this.PopulateStudentList();

            this.RaisePropertyChanged(nameof(this.StudentViewModel));

        }
    }

}
