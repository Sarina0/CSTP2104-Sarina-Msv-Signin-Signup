namespace StudentCoopViewModel
{
    using StudentCoopCommon.Interfaces;
    using StudentCoopCommon.ViewModels;

    using System;

    public class StudentViewModel
    {
        private readonly Student student;
        private readonly IStudentRepository studentRepository;

        public StudentViewModel(Student student, IStudentRepository studentRepository)
        {
            this.student = student;
            this.studentRepository = studentRepository;
        }

        public int ID
        {
            get => this.student.id;
        }

        public string FirstName
        {
            get
            {
                return this.student.first;
            }

            set
            {
                this.student.first = value;
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
                this.student.last = value;
            }
        }
    }
}
