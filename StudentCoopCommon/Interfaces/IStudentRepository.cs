using System;
using System.Collections.Generic;
using System.Text;
using StudentCoopCommon.ViewModels;

namespace StudentCoopCommon.Interfaces
{
    public interface IStudentRepository
    {
        void Add(Student student);
        Student Get(int id);
        void Delete(string id);
        void Update(Student student);
        void StudentGet();
    }
}
