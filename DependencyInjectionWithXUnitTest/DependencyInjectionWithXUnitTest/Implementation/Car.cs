using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection_UnitTest
{
    public class Car : ICar
    {

        private readonly IEngine _engine;

        private readonly List<IWheel> _wheels;

        private readonly IBrakingSystem _brakingSystem;

        private bool _isBrakeApplied = false;

        public Car(IEngine engine, List<IWheel> wheels, IBrakingSystem brakingSystem)
        {
            this._engine = engine;
            this._wheels = wheels;
            this._brakingSystem = brakingSystem;
        }

        public string Brake()
        {
            string returnString = string.Empty;
            this._isBrakeApplied = true;
            returnString += this._brakingSystem.ApplyBrake();
            foreach (IWheel wheel in this._wheels)
            {
                string instructions = wheel.Stop();
                returnString += string.IsNullOrEmpty(returnString) ? instructions : $"||{instructions}";
            }
            return returnString;
        }

        public string Drive()
        {
            string returnString = string.Empty;
            if (this._isBrakeApplied)
            {
                returnString += this._brakingSystem.ReleaseBrake();
                this._isBrakeApplied = false;
            }
            foreach(IWheel wheel in this._wheels)
            {
                string instructions = wheel.Start();
                returnString += string.IsNullOrEmpty(returnString) ? instructions :$"||{instructions}";
            }
            return returnString;
        }

        public string Start()
        {
            return this._engine.On();
        }

        public string Stop()
        {
            string returnString = string.Empty;
            foreach (IWheel wheel in this._wheels)
            {
                returnString += $"{wheel.Stop()}||";
            }
            returnString += this._engine.Off();
            return returnString;
        }

        public string TestDrive()
        {
            return string.Join("||", new string[] {
            this.Start(),
            this.Drive(),
            this.Brake(),
            this.Drive(),
            this.Stop() });
        }
    }
}
