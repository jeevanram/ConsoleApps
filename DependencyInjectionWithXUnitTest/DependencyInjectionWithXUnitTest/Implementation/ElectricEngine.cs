using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection_UnitTest
{
    public class ElectricEngine : IEngine
    {
        public string Off()
        {
            return $"ElectricEngine OFF : Battery Power OFF.";
        }

        public string On()
        {
            return $"ElectricEngine ON : Battery Power ON : Quickly picks up.";
        }
    }
}
