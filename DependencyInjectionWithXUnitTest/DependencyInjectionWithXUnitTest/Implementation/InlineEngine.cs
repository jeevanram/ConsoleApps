using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection_UnitTest
{
    public class InlineEngine : IEngine
    {
        public string Off()
        {
            return $"Inline Engine OFF : Ignition OFF.";
        }

        public string On()
        {
            return $"InlineEngine ON : Ignition ON > Gradually picks up.";
        }
    }
}
