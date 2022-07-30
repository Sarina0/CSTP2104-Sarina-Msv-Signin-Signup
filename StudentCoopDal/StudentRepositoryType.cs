using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCoopDal
{
    public enum StudentRepositoryType
    {
        Unknown,
        InMemoryStudentRepository,
        SqlStudentRepository,
        OracleStudentRepository,
        ExcelStudentRepository,
        WebServiceStudentRepository,
        AzureCloudStudentRepository
        
    }
}
