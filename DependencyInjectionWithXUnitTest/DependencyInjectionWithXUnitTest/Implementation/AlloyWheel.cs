using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection_UnitTest
{
    public class AlloyWheel : IWheel
    {
        public string WheelPosition { get; set; }

        public AlloyWheel(string wheelPosition)
        {
            this.WheelPosition = wheelPosition;
        }

        public string Start()
        {
            return $"Wheel Position - {this.WheelPosition} - Rust free alloy wheel starts spinning.";
        }

        public string Stop()
        {
            return $"Wheel Position - {this.WheelPosition} - Rust free alloy wheel stops spinning.";
        }
    }
}
