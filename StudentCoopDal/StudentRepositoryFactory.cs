﻿using StudentCoopCommon.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCoopDal
{
    public class StudentRepositoryFactory
    {
        public IStudentRepository Create(StudentRepositoryType studentRepositoryType)
        {
            if (studentRepositoryType == StudentRepositoryType.InMemoryStudentRepository)
            {
                return new StudentRepository(null);

            }
            else if (studentRepositoryType == StudentRepositoryType.SqlStudentRepository)
            {
                return new StudentSqlRepository();
            }

            throw new ArgumentException("StudentRepositoryType is unknown");
        }
    }
}
