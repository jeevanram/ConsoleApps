using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection_UnitTest
{
    class VEngine : IEngine
    {
        public string Off()
        {
            return $"VEngine engine OFF : Ignition OFF.";
        }

        public string On()
        {
            return $"VEngine ON : Ignition ON > Quickly picks up.";
        }
    }
}
