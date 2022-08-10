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
        public string BirthDay
        {
            get
            {
                return this.student.date;
            }

            set
            {
                if (value != null)
                {
                    this.student.date = value;
                    this.RaisePropertyChanged(nameof(BirthDay));
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

        public string Address
        {
            get
            {
                return this.student.add;
            }

            set
            {
                if (value != null)
                {
                    this.student.add = value;
                    this.RaisePropertyChanged(nameof(Address));
                }
            }
        }
        public int PhoneNum
        {
            get
            {
                return this.student.phone;
            }

            set
            {
                if (value != 0)
                {
                    this.student.phone= value;
                    this.RaisePropertyChanged(nameof(PhoneNum));
                }
            }
        }
        public void Save()
        {
            this.studentRepository.Update(this.student.id, this.student);
        }
        public int IDGet()
        {
            // int id = this.studentRepository.Get(this.student.id);
            int some = this.studentRepository.IDGet(this.student.id);
            return some;

        }
        public void Login()
        {
            this.studentRepository.Get(this.student.id);
        }
        public void Add()
        {
            this.studentRepository.Add(this.student);
        }
    }
}