using StudentCoopCommon.Interfaces;
using StudentCoopCommon.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCoopViewModel
{
    public class MainViewModel
    {
        public StudentViewModel StudentViewModel { get; private set; }
        private readonly IStudentRepository studentRepository;
        private const int studentIdToFatch = 10;

        public MainViewModel(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public void Load()
        {
            var student = this.studentRepository.Get(studentIdToFatch);
            if (student != null)
            {
                this.StudentViewModel = new StudentViewModel(student, this.studentRepository);
            }
        }
    }
}
