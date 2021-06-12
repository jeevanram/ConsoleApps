using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection_UnitTest
{
    class DiscBrakingSystem : IBrakingSystem
    {
        public string ApplyBrake()
        {
            return $"Apply Disc Brake";
        }

        public string ReleaseBrake()
        {
            return $"Release Disc Brake";
        }
    }
}
