using StudentCoopCommon;
using StudentCoopCommon.Interfaces;
using StudentCoopCommon.ViewModels;

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

        public void GetAllStudent()
        {
            this.studentRepository.StudentGet();

        }
        
        public void Add()
        { 
            var student1 = new Student();
            student1.id = 133;
            student1.first = "Melik2";
            student1.last = "Smithh";
            student1.add = "Vancouver bc 22 victoria stf";
            student1.date = "2001 september 19";
            student1.phone = 32493;
            this.studentRepository.Add(student1);

        }
        public int GetID()
        {
            var student2 = new Student();
            var id2 = student2.id = 21443;
            int some = this.studentRepository.IDGet(id2);
            return some;
        }
        public void GetById()
        { 
            var student2 = new Student();
            var id2 = student2.id = 133;
            this.studentRepository.Get(id2);
      
        }
        
        public void DeleteStudent()
        { var student3 = new Student();
            var id2 = student3.id = 324;
            this.studentRepository.Delete(id2);
        }
        public void UpdateStudent()
        {
            var student2 = new Student();
            string first = student2.first = "Melika";
            string last = student2.last = "Smith";
            int id = student2.id = 133;
            this.studentRepository.Update(id, student2);

        }
    }
}
