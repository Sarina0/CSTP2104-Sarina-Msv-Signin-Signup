using StudentCoopCommon.ViewModels;

using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCoopCommon.Interfaces
{
    public interface IStudentRepository
    {

        Student Get(int id);
        void Add(Student student);
        void Delete(int id);
        List<Student> Get();
        void Update(int id, Student student);
        void StudentGet();


    }
}
