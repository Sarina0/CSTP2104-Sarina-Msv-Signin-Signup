using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCoopCommon.Interfaces
{
    public interface IStudentRepository
    {
        void Add(Student student);
        Student Get(string id);
        void Delete(string id);
        void Update(Student student);
    }
}
