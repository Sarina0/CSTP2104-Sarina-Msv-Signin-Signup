using StudentCoopCommon;
using StudentCoopCommon.Interfaces;
using StudentCoopDal;

using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCoopBL
{
    public class StudentManager
    {
        private readonly IStudentRepository studentRepository;
        private readonly ILogger logger;

        public StudentManager(IStudentRepository studentRepository, ILogger logger)
        {
            this.studentRepository = studentRepository;
            this.logger = logger;
        }

        public void Add(Student student)
        {
            this.studentRepository.Add(student);
        }

        public Student Get(string id)
        {
            this.logger.Log($"studentManager get id:{id}");
            var student = this.studentRepository.Get(id);

            if (student != null)
            {
                this.logger.Log($"studentManager get id:{student.ID} name:{student.FirstName}");
            }

            return student;
        }
    }
}
