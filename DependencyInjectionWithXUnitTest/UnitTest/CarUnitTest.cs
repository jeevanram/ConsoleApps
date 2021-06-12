using DependencyInjection_UnitTest;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace UnitTest
{
    public class CarUnitTest
    {
        private Car GetCarTestObject()
        {
            var mockEngine = new Mock<IEngine>();
            var mockBrakingSystem = new Mock<IBrakingSystem>();
            var mockWheels = new Mock<List<IWheel>>();

            mockEngine.Setup(engine => engine.On()).Returns("Engine ON");
            mockEngine.Setup(engine => engine.Off()).Returns("Engine OFF");

            mockBrakingSystem.Setup(brakingSystem => brakingSystem.ApplyBrake()).Returns("Brakes Applied");
            mockBrakingSystem.Setup(brakingSystem => brakingSystem.ReleaseBrake()).Returns("Brakes Released");

            var mockFrontLeftWheel = new Mock<IWheel>();
            mockFrontLeftWheel.Setup(wheel => wheel.Start()).Returns("Front Left Wheel Spinning");
            mockFrontLeftWheel.Setup(wheel => wheel.Stop()).Returns("Front Left Wheel Stops Spinning");
            var mockFrontRightWheel = new Mock<IWheel>();
            mockFrontRightWheel.Setup(wheel => wheel.Start()).Returns("Front Right Wheel Spinning");
            mockFrontRightWheel.Setup(wheel => wheel.Stop()).Returns("Front Right Wheel Stops Spinning");
            var mockRearLeftWheel = new Mock<IWheel>();
            mockRearLeftWheel.Setup(wheel => wheel.Start()).Returns("Rear Left Wheel Spinning");
            mockRearLeftWheel.Setup(wheel => wheel.Stop()).Returns("Rear Left Wheel Stops Spinning");
            var mockRearRightWheel = new Mock<IWheel>();
            mockRearRightWheel.Setup(wheel => wheel.Start()).Returns("Rear Right Wheel Spinning");
            mockRearRightWheel.Setup(wheel => wheel.Stop()).Returns("Rear Right Wheel Stops Spinning");

            var wheelList = new List<IWheel>()
            {
                mockFrontLeftWheel.Object, mockFrontRightWheel.Object, mockRearLeftWheel.Object, mockRearRightWheel.Object
            };

            return new Car(mockEngine.Object, wheelList, mockBrakingSystem.Object);
        }

        [Fact]
        public void TestDrive()
        {
            var carTestObject = GetCarTestObject();
            string expectedResult = "Engine ON||Front Left Wheel Spinning||Front Right Wheel Spinning||Rear Left Wheel Spinning||Rear Right Wheel Spinning" +
                "||Brakes Applied||Front Left Wheel Stops Spinning||Front Right Wheel Stops Spinning||Rear Left Wheel Stops Spinning||Rear Right Wheel Stops Spinning" +
                "||Brakes Released||Front Left Wheel Spinning||Front Right Wheel Spinning||Rear Left Wheel Spinning||Rear Right Wheel Spinning" +
                "||Front Left Wheel Stops Spinning||Front Right Wheel Stops Spinning||Rear Left Wheel Stops Spinning||Rear Right Wheel Stops Spinning||Engine OFF";
            string actualResult = carTestObject.TestDrive();
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Brake()
        {
            var carTestObject = GetCarTestObject();
            string expectedResult = "Brakes Applied||Front Left Wheel Stops Spinning||Front Right Wheel Stops Spinning||Rear Left Wheel Stops Spinning||Rear Right Wheel Stops Spinning";
            string actualResult = carTestObject.Brake();
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void BrakeWithApplyBrakeReturnEmpty()
        {
            var mockEngine = new Mock<IEngine>();
            var mockBrakingSystem = new Mock<IBrakingSystem>();
            var mockWheels = new Mock<List<IWheel>>();

            mockEngine.Setup(engine => engine.On()).Returns("Engine ON");
            mockEngine.Setup(engine => engine.Off()).Returns("Engine OFF");

            var mockFrontLeftWheel = new Mock<IWheel>();
            mockFrontLeftWheel.Setup(wheel => wheel.Start()).Returns("Front Left Wheel Spinning");
            mockFrontLeftWheel.Setup(wheel => wheel.Stop()).Returns("Front Left Wheel Stops Spinning");
            var mockFrontRightWheel = new Mock<IWheel>();
            mockFrontRightWheel.Setup(wheel => wheel.Start()).Returns("Front Right Wheel Spinning");
            mockFrontRightWheel.Setup(wheel => wheel.Stop()).Returns("Front Right Wheel Stops Spinning");
            var mockRearLeftWheel = new Mock<IWheel>();
            mockRearLeftWheel.Setup(wheel => wheel.Start()).Returns("Rear Left Wheel Spinning");
            mockRearLeftWheel.Setup(wheel => wheel.Stop()).Returns("Rear Left Wheel Stops Spinning");
            var mockRearRightWheel = new Mock<IWheel>();
            mockRearRightWheel.Setup(wheel => wheel.Start()).Returns("Rear Right Wheel Spinning");
            mockRearRightWheel.Setup(wheel => wheel.Stop()).Returns("Rear Right Wheel Stops Spinning");

            var wheelList = new List<IWheel>()
            {
                mockFrontLeftWheel.Object, mockFrontRightWheel.Object, mockRearLeftWheel.Object, mockRearRightWheel.Object
            };
            var carTestObject = new Car(mockEngine.Object, wheelList, mockBrakingSystem.Object);
            string expectedResult = "Front Left Wheel Stops Spinning||Front Right Wheel Stops Spinning||Rear Left Wheel Stops Spinning||Rear Right Wheel Stops Spinning";
            string actualResult = carTestObject.Brake();
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void ElectricCarTestDrive()
        {
            var mockEngine = new Mock<IEngine>();
            var mockBrakingSystem = new Mock<IBrakingSystem>();
            var mockWheels = new Mock<List<IWheel>>();

            mockEngine.Setup(engine => engine.On()).Returns((new ElectricEngine()).On());
            mockEngine.Setup(engine => engine.Off()).Returns((new ElectricEngine()).Off());

            mockBrakingSystem.Setup(brakingSystem => brakingSystem.ApplyBrake()).Returns((new AntiLockBrakingSystem()).ApplyBrake());
            mockBrakingSystem.Setup(brakingSystem => brakingSystem.ReleaseBrake()).Returns((new AntiLockBrakingSystem()).ReleaseBrake());

            var mockFrontLeftWheel = new Mock<IWheel>();
            mockFrontLeftWheel.Setup(wheel => wheel.Start()).Returns((new AlloyWheel("Front Left")).Start());
            mockFrontLeftWheel.Setup(wheel => wheel.Stop()).Returns((new AlloyWheel("Front Left")).Stop());
            var mockFrontRightWheel = new Mock<IWheel>();
            mockFrontRightWheel.Setup(wheel => wheel.Start()).Returns((new AlloyWheel("Front Right")).Start());
            mockFrontRightWheel.Setup(wheel => wheel.Stop()).Returns((new AlloyWheel("Front Right")).Stop());
            var mockRearLeftWheel = new Mock<IWheel>();
            mockRearLeftWheel.Setup(wheel => wheel.Start()).Returns((new AlloyWheel("Rear Left")).Start());
            mockRearLeftWheel.Setup(wheel => wheel.Stop()).Returns((new AlloyWheel("Rear Left")).Stop());
            var mockRearRightWheel = new Mock<IWheel>();
            mockRearRightWheel.Setup(wheel => wheel.Start()).Returns((new AlloyWheel("Rear Right")).Start());
            mockRearRightWheel.Setup(wheel => wheel.Stop()).Returns((new AlloyWheel("Rear Right")).Stop());

            var wheelList = new List<IWheel>()
            {
                mockFrontLeftWheel.Object, mockFrontRightWheel.Object, mockRearLeftWheel.Object, mockRearRightWheel.Object
            };
            var carTestObject = new Car(mockEngine.Object, wheelList, mockBrakingSystem.Object);
            string expectedResult = "ElectricEngine ON : Battery Power ON : Quickly picks up.||Wheel Position - Front Left - Rust free alloy wheel starts spinning.||Wheel Position - Front Right - Rust free alloy wheel starts spinning.||" +
                "Wheel Position - Rear Left - Rust free alloy wheel starts spinning.||Wheel Position - Rear Right - Rust free alloy wheel starts spinning.||Apply Anti-lock Braking System||Wheel Position - Front Left - Rust free alloy wheel stops spinning.||" +
                "Wheel Position - Front Right - Rust free alloy wheel stops spinning.||Wheel Position - Rear Left - Rust free alloy wheel stops spinning.||Wheel Position - Rear Right - Rust free alloy wheel stops spinning.||Release Anti-lock Braking System||" +
                "Wheel Position - Front Left - Rust free alloy wheel starts spinning.||Wheel Position - Front Right - Rust free alloy wheel starts spinning.||Wheel Position - Rear Left - Rust free alloy wheel starts spinning.||Wheel Position - Rear Right - Rust free alloy wheel starts spinning.||" +
                "Wheel Position - Front Left - Rust free alloy wheel stops spinning.||Wheel Position - Front Right - Rust free alloy wheel stops spinning.||Wheel Position - Rear Left - Rust free alloy wheel stops spinning.||Wheel Position - Rear Right - Rust free alloy wheel stops spinning.||" +
                "ElectricEngine OFF : Battery Power OFF.";
            string actualResult = carTestObject.TestDrive();
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("BasicModel", "InlineEngine ON : Ignition ON > Gradually picks up.||Wheel Position - FrontLeftWheel - Steel wheel starts spinning.||Wheel Position - FrontRightWheel - Steel wheel starts spinning.||" +
                "Wheel Position - RearLeftWheel - Steel wheel starts spinning.||Wheel Position - RearRightWheel - Steel wheel starts spinning.||Apply Disc Brake||Wheel Position - FrontLeftWheel - Steel wheel stops spinning.||" +
                "Wheel Position - FrontRightWheel - Steel wheel stops spinning.||Wheel Position - RearLeftWheel - Steel wheel stops spinning.||Wheel Position - RearRightWheel - Steel wheel stops spinning.||Release Disc Brake||" +
                "Wheel Position - FrontLeftWheel - Steel wheel starts spinning.||Wheel Position - FrontRightWheel - Steel wheel starts spinning.||Wheel Position - RearLeftWheel - Steel wheel starts spinning.||Wheel Position - RearRightWheel - Steel wheel starts spinning.||" +
                "Wheel Position - FrontLeftWheel - Steel wheel stops spinning.||Wheel Position - FrontRightWheel - Steel wheel stops spinning.||Wheel Position - RearLeftWheel - Steel wheel stops spinning.||Wheel Position - RearRightWheel - Steel wheel stops spinning.||" +
                "Inline Engine OFF : Ignition OFF.")]
        [InlineData("xyz", "InlineEngine ON : Ignition ON > Gradually picks up.||Wheel Position - FrontLeftWheel - Steel wheel starts spinning.||Wheel Position - FrontRightWheel - Steel wheel starts spinning.||" +
                "Wheel Position - RearLeftWheel - Steel wheel starts spinning.||Wheel Position - RearRightWheel - Steel wheel starts spinning.||Apply Disc Brake||Wheel Position - FrontLeftWheel - Steel wheel stops spinning.||" +
                "Wheel Position - FrontRightWheel - Steel wheel stops spinning.||Wheel Position - RearLeftWheel - Steel wheel stops spinning.||Wheel Position - RearRightWheel - Steel wheel stops spinning.||Release Disc Brake||" +
                "Wheel Position - FrontLeftWheel - Steel wheel starts spinning.||Wheel Position - FrontRightWheel - Steel wheel starts spinning.||Wheel Position - RearLeftWheel - Steel wheel starts spinning.||Wheel Position - RearRightWheel - Steel wheel starts spinning.||" +
                "Wheel Position - FrontLeftWheel - Steel wheel stops spinning.||Wheel Position - FrontRightWheel - Steel wheel stops spinning.||Wheel Position - RearLeftWheel - Steel wheel stops spinning.||Wheel Position - RearRightWheel - Steel wheel stops spinning.||" +
                "Inline Engine OFF : Ignition OFF.")]
        [InlineData("SportsModel", "VEngine ON : Ignition ON > Quickly picks up.||Wheel Position - FrontLeftWheel - Rust free alloy wheel starts spinning.||Wheel Position - FrontRightWheel - Rust free alloy wheel starts spinning.||" +
                "Wheel Position - RearLeftWheel - Rust free alloy wheel starts spinning.||Wheel Position - RearRightWheel - Rust free alloy wheel starts spinning.||Apply Disc Brake||Wheel Position - FrontLeftWheel - Rust free alloy wheel stops spinning.||" +
                "Wheel Position - FrontRightWheel - Rust free alloy wheel stops spinning.||Wheel Position - RearLeftWheel - Rust free alloy wheel stops spinning.||Wheel Position - RearRightWheel - Rust free alloy wheel stops spinning.||Release Disc Brake||" +
                "Wheel Position - FrontLeftWheel - Rust free alloy wheel starts spinning.||Wheel Position - FrontRightWheel - Rust free alloy wheel starts spinning.||Wheel Position - RearLeftWheel - Rust free alloy wheel starts spinning.||Wheel Position - RearRightWheel - Rust free alloy wheel starts spinning.||" +
                "Wheel Position - FrontLeftWheel - Rust free alloy wheel stops spinning.||Wheel Position - FrontRightWheel - Rust free alloy wheel stops spinning.||Wheel Position - RearLeftWheel - Rust free alloy wheel stops spinning.||Wheel Position - RearRightWheel - Rust free alloy wheel stops spinning.||" +
                "VEngine engine OFF : Ignition OFF.")]
        [InlineData("ElectricModel", "ElectricEngine ON : Battery Power ON : Quickly picks up.||Wheel Position - FrontLeftWheel - Rust free alloy wheel starts spinning.||Wheel Position - FrontRightWheel - Rust free alloy wheel starts spinning.||" +
                "Wheel Position - RearLeftWheel - Rust free alloy wheel starts spinning.||Wheel Position - RearRightWheel - Rust free alloy wheel starts spinning.||Apply Anti-lock Braking System||Wheel Position - FrontLeftWheel - Rust free alloy wheel stops spinning.||" +
                "Wheel Position - FrontRightWheel - Rust free alloy wheel stops spinning.||Wheel Position - RearLeftWheel - Rust free alloy wheel stops spinning.||Wheel Position - RearRightWheel - Rust free alloy wheel stops spinning.||Release Anti-lock Braking System||" +
                "Wheel Position - FrontLeftWheel - Rust free alloy wheel starts spinning.||Wheel Position - FrontRightWheel - Rust free alloy wheel starts spinning.||Wheel Position - RearLeftWheel - Rust free alloy wheel starts spinning.||Wheel Position - RearRightWheel - Rust free alloy wheel starts spinning.||" +
                "Wheel Position - FrontLeftWheel - Rust free alloy wheel stops spinning.||Wheel Position - FrontRightWheel - Rust free alloy wheel stops spinning.||Wheel Position - RearLeftWheel - Rust free alloy wheel stops spinning.||Wheel Position - RearRightWheel - Rust free alloy wheel stops spinning.||" +
                "ElectricEngine OFF : Battery Power OFF.")]
        public void ModelTestDrive(string model,string testDriveInstructions)
        {
            Program pgm = new Program();
            string resultInstructions = pgm.TestDrive(model);
            Assert.Equal(testDriveInstructions, resultInstructions);
        }
    }
}
