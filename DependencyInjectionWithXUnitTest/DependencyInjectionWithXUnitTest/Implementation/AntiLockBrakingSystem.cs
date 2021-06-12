using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection_UnitTest
{
    public class AntiLockBrakingSystem : IBrakingSystem
    {
        public string ApplyBrake()
        {
            return $"Apply Anti-lock Braking System";
        }

        public string ReleaseBrake()
        {
            return $"Release Anti-lock Braking System";
        }
    }
}
