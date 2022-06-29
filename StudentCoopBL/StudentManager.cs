using StudentCoopCommon;

using StudentCoopDal;

using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCoopBL
{
    public class StudentManager
    {
        private readonly StudentRepository studentRepository;

        public StudentManager()
        {
            this.studentRepository = new StudentRepository();
        }

        public void Add(Student student)
        {
            this.studentRepository.Add(student);
        }

        public Student Get(string id)
        {
            return this.studentRepository.Get(id);
        }
    }
}