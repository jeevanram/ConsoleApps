using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection_UnitTest
{
    class SteelWheel : IWheel
    {
        public string WheelPosition { get; set; }

        public SteelWheel(string wheelPosition)
        {
            this.WheelPosition = wheelPosition;
        }

        public string Start()
        {
            return $"Wheel Position - {this.WheelPosition} - Steel wheel starts spinning.";
        }

        public string Stop()
        {
            return $"Wheel Position - {this.WheelPosition} - Steel wheel stops spinning.";
        }
    }
}
