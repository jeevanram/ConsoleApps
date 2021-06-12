using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection_UnitTest
{
    public interface ICar
    {
        public string Start();
        public string Drive();
        public string Brake();
        public string Stop();
        public string TestDrive();
    }
}
