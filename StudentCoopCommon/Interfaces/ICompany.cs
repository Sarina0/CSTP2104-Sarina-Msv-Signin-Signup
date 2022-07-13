using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCoopCommon.Interfaces
{
    public interface ICompany
    {
        void Add(Company company);
        Company Get(string id);
        void Delete(int id);
        void Update(Company company);
    }
}
