using System;
using System.Collections.Generic;
using System.Text;

namespace CSTP2104.Shared
{
    public class AssignmentBase
    {
        protected virtual void Execute()
        {
        }

        public void Run()
        {
            this.Execute();
        }



    }
}
