namespace StudentCoopViewModel
{
    using StudentCoopCommon.Interfaces;
    using StudentCoopCommon.ViewModels;

    using System;

    public class StudentViewModel : ViewModelBase
    {
        private readonly Student student;
        private readonly IStudentRepository studentRepository;

        public StudentViewModel(IStudentRepository studentRepository)
        {
            this.student = new Student();
            this.studentRepository = studentRepository;
        }

        public int ID
        {
            get
            {
                return this.student.id;
            }

            set
            {
                if (value != 0)
                {
                    this.student.id = value;
                    this.RaisePropertyChanged(nameof(ID));
                }
            }
        }

        public string FirstName
        {
            get
            {
                return this.student.first;
            }

            set
            {
                if (value != null)
                {
                    this.student.first = value;
                    this.RaisePropertyChanged(nameof(FirstName));
                }
            }
        }

        public string LastName
        {
            get
            {
                return this.student.last;
            }

            set
            {
                if (value != null)
                {
                    this.student.last = value;
                    this.RaisePropertyChanged(nameof(LastName));
                }
            }
        }

        public void Save()
        {
            this.studentRepository.Update(this.student.id, this.student);
            var isValid = this.student == null;
            if (!isValid)
            {
                
            }
        }
        public void Login()
        {
            this.studentRepository.Get(this.student.id);
        }
    }
}