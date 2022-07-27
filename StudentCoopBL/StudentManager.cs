using StudentCoopCommon;
using StudentCoopCommon.Interfaces;
using StudentCoopDal;
using StudentCoopCommon.ViewModels;
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

        public Student Get(int id)
        {
            this.logger.Log($"studentManager get id:{id}");
            var student = this.studentRepository.Get(id);

            if (student != null)
            {
                this.logger.Log($"studentManager get id:{student.id} name:{student.first}");
            }

            return student;
        }
        public void StudentGet()
        {
            this.studentRepository.StudentGet();
        }
    }
}