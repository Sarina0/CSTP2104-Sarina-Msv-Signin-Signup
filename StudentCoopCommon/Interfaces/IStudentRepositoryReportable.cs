using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCoopCommon.Interfaces
{
    public interface IStudentRepositoryReportable : IStudentRepository
    {
        IEnumerable<Student> Get(IEnumerable<string> filters);
    }
}
