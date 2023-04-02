using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScooterProject;

namespace ScooterProject
{

    [TestClass]
    public class MyScooterTestPhase3
    {
        private const double BatteryCapacity = 250;
        private const int HoursBetweenUpdates = 48;

        [TestMethod]
        public void TestDefaultConstructor()
        {
            //Arrange
            Scooter testScooter = new Scooter();

            //Act
            string app = testScooter.App;

            //Assert
            Assert.AreEqual(app, "Spin", "The expected app is Spin");
            Assert.AreEqual(testScooter.Model, "SegwayES4", "The expected model is SegwayES4");
            Assert.AreEqual(testScooter.Year, 2021, "The expected year is 2021");
            Assert.AreEqual(testScooter.Wph, 20.0, 0.01, "The expected watts per hour is 20.0");
            Assert.AreEqual(testScooter.Charge, BatteryCapacity, 0.01, "The expected charge is 250");
            Assert.AreEqual(testScooter.HoursNextSoftwareUpdate, HoursBetweenUpdates, 0.01, "The next software update should be @48");
        }

        [TestMethod]
        public void TestOverloadedConstructor()
        {
            //Arrange
            Scooter testScooter = new Scooter("Bird", "Razor", 2019, 30.0);

            //Act
            string app = testScooter.App;

            //Assert
            Assert.AreEqual(app, "Bird", "The expected make is Bird");
            Assert.AreEqual(testScooter.Model, "Razor", "The expected model is Razor");
            Assert.AreEqual(testScooter.Year, 2019, "The expected year is 2019");
            Assert.AreEqual(testScooter.Wph, 30.0, 0.01, "The expected watts per hour is 30.0");
            Assert.AreEqual(testScooter.Charge, BatteryCapacity, 0.01, "The expected charge is 250");
            Assert.AreEqual(testScooter.HoursNextSoftwareUpdate, HoursBetweenUpdates, 0.01, "The next software update should be @48");
        }

        [TestMethod]
        public void TestSetApp()
        {
            //Arrange
            Scooter testScooter = new Scooter("Spin", "SegwayES4", 2021, 20);

            //Act
            string newApp = "Bird";
            testScooter.App = newApp;

            //Assert
            Assert.AreEqual(testScooter.App, newApp, "Scooter app should be equal to input parameter");
        }

        [TestMethod]
        public void TestSetModel()
        {
            //Arrange
            Scooter testScooter = new Scooter("Spin", "SegwayES4", 2021, 20);

            //Act
            string newModel = "Razor";
            testScooter.Model = newModel;

            //Assert
            Assert.AreEqual(testScooter.Model, newModel, "Scooter model should be equal to input parameter");
        }

        [TestMethod]
        public void TestSetYear()
        {
            //Arrange
            Scooter testScooter = new Scooter("Spin", "SegwayES4", 2021, 20);

            //Act
            int newYear = 2019;
            testScooter.Year = newYear;

            //Assert
            Assert.AreEqual(testScooter.Year, newYear, "Scooter year should be equal to input parameter");
        }

        [TestMethod]
        public void TestSetWPH()
        {
            //Arrange
            Scooter testScooter = new Scooter("Spin", "SegwayES4", 2021, 20);

            //Act
            double newWPH = 30;
            testScooter.Wph = newWPH;

            //Assert
            Assert.AreEqual(testScooter.Wph, newWPH, 0.01, "Scooter WPH should be equal to input parameter");
        }


        [TestMethod]
        public void TestChargeBatteryNegativeValScooterLocked()
        {
            //Arrange
            Scooter testScooter = new Scooter();

            //Act
            testScooter.LockScooter();
            testScooter.ChargeBattery(-10);

            //Assert
            Assert.AreEqual(testScooter.Charge, BatteryCapacity, 0.01, "Battery charge should " +
                "not change when trying to add charge with a negative value");
        }

        [TestMethod]
        public void TestChargeBatteryNegativeValScooterUnlocked()
        {
            //Arrange
            Scooter testScooter = new Scooter();

            //Act
            testScooter.UnlockScooter();
            double previousCharge = testScooter.Charge;
            testScooter.ChargeBattery(-10);

            //Assert
            Assert.AreEqual(testScooter.Charge, previousCharge, 0.01, "You cannot add charge" +
                "because the scooter is unlocked.");
        }

        [TestMethod]
        public void TestChargeBatteryOverChargeScooterLocked()
        {
            //Arrange
            Scooter testScooter = new Scooter();

            //Act
            testScooter.LockScooter();
            testScooter.ChargeBattery(10);

            //Assert
            Assert.AreEqual(testScooter.Charge, BatteryCapacity, 0.01, "Battery charge should " +
                "not change when trying to over charge the battery");


            //Trying to add more charge than required to charge the battery
            //Arrange
            Scooter testScooter2 = new Scooter();

            //Act
            testScooter2.UnlockScooter();
            testScooter2.Ride(2);
            testScooter2.LockScooter();
            testScooter2.ChargeBattery(50);

            //Assert
            Assert.AreEqual(testScooter2.Charge, BatteryCapacity, 0.01, "Battery charge should " +
                "be at most, the battery capacity");
        }

        [TestMethod]
        public void TestChargeBatteryOverChargeScooterUnlocked()
        {
            //Arrange
            Scooter testScooter = new Scooter();

            //Act
            testScooter.UnlockScooter();
            double previousCharge = testScooter.Charge;
            testScooter.ChargeBattery(10);

            //Assert
            Assert.AreEqual(testScooter.Charge, previousCharge, 0.01, "You cannot charge battery " +
                "because the scooter is unlocked");


            //Trying to add more charge than required to charge the battery
            //Arrange
            Scooter testScooter2 = new Scooter();

            //Act
            testScooter2.UnlockScooter();
            testScooter2.Ride(2);
            double previousCharge2 = testScooter2.Charge;
            testScooter2.ChargeBattery(50);

            //Assert
            Assert.AreEqual(testScooter2.Charge, previousCharge2, 0.01, "You cannot charge " +
                "because the scooter is unlocked");
        }

        [TestMethod]
        public void TestChargeBatteryOKValScooterLocked()
        {
            //Arrange
            Scooter testScooter = new Scooter();

            //Act
            testScooter.UnlockScooter();
            testScooter.Ride(1);
            testScooter.LockScooter();
            testScooter.ChargeBattery(10);

            //Assert
            Assert.AreEqual(testScooter.Charge, 240, 0.01, "Battery charge should be 240");
        }

        [TestMethod]
        public void TestChargeBatteryOKValScooterUnlocked()
        {
            //Arrange
            Scooter testScooter = new Scooter();

            //Act
            testScooter.UnlockScooter();
            testScooter.Ride(1);
            double previousCharge = testScooter.Charge;
            testScooter.ChargeBattery(10);

            //Assert
            Assert.AreEqual(testScooter.Charge, previousCharge, 0.01, "You cannot charge " +
                "because the scooter is unlocked");
        }


        [TestMethod]
        public void TestChargeBatteryOKIncrementsScooterLocked()
        {
            //Arrange
            Scooter testScooter = new Scooter();

            //Act
            testScooter.UnlockScooter();
            testScooter.Ride(3);
            testScooter.LockScooter();
            testScooter.ChargeBattery(10);
            testScooter.ChargeBattery(10);

            //Assert
            Assert.AreEqual(testScooter.Charge, 210, 0.01, "Battery charge should be 210");
        }

        [TestMethod]
        public void TestChargeBatteryOKIncrementsScooterUnlocked()
        {
            //Arrange
            Scooter testScooter = new Scooter();

            //Act
            testScooter.UnlockScooter();
            testScooter.Ride(3);
            double previousCharge = testScooter.Charge;
            testScooter.ChargeBattery(10);
            testScooter.ChargeBattery(10);

            //Assert
            Assert.AreEqual(testScooter.Charge, previousCharge, 0.01, "You cannot charge " +
                "because the scooter is unlocked");
        }

        [TestMethod]
        public void TestRideNegativeValScooterUnlocked()
        {
            //Arrange
            Scooter testScooter = new Scooter();

            //Act
            testScooter.Ride(-2);

            //Assert
            Assert.AreEqual(testScooter.Charge, BatteryCapacity, 0.01, "Battery charge should " +
                "not change when trying to ride negative hours");

            Assert.AreEqual(testScooter.Hours, 0.0, 0.01, "Hours should not " +
                "change when trying to ride negative hours");
        }

        [TestMethod]
        public void TestRideNegativeValScooterLocked()
        {
            //Arrange
            Scooter testScooter = new Scooter();

            //Act
            testScooter.LockScooter();
            double previousCharge = testScooter.Charge;
            double previousHours = testScooter.Hours;

            testScooter.Ride(-2);

            //Assert
            Assert.AreEqual(testScooter.Charge, previousCharge, 0.01, "You cannot ride " +
                "because the scooter is locked");

            Assert.AreEqual(testScooter.Hours, previousHours, 0.01, "You cannot ride " +
                "because the scooter is locked");
        }

        [TestMethod]
        public void TestRideOKValScooterUnlocked()
        {
            //Arrange
            Scooter testScooter = new Scooter();

            //Act
            testScooter.UnlockScooter();
            testScooter.Ride(2);

            //Assert
            Assert.AreEqual(testScooter.Charge, 210, 0.01, "Problem with formula " +
                "to update the batery charge after riding, battery charge should decrement");

            Assert.AreEqual(testScooter.Hours, 2, 0.01, "Problem with formula " +
                "to update hours after riding, hours should increment");
        }

        [TestMethod]
        public void TestRideOKValScooterLocked()
        {
            //Arrange
            Scooter testScooter = new Scooter();

            //Act
            testScooter.LockScooter();
            double previousCharge = testScooter.Charge;
            double previousHours = testScooter.Hours;
            testScooter.Ride(2);

            //Assert
            Assert.AreEqual(testScooter.Charge, previousCharge, 0.01, "You cannot ride " +
                "because the scooter is locked");

            Assert.AreEqual(testScooter.Hours, previousHours, 0.01, "You cannot ride " +
                "because the scooter is locked");
        }

        [TestMethod]
        public void TestRunningOutBatteryChargeScooterUnlocked()
        {
            //Arrange
            Scooter testScooter = new Scooter();

            //Act
            testScooter.UnlockScooter();
            testScooter.Ride(15);

            //Assert
            Assert.AreEqual(testScooter.Charge, 0, 0.01, "Problem with formula " +
                "to update the battery charge after running out of charge. It should be zero ");

            Assert.AreEqual(testScooter.Hours, 12.5, 0.01, "Problem with formula " +
                "to update hours, hours should be 12.5");

            Assert.IsFalse(testScooter.IsUnlocked(), "Scooter ran out of battery charge, " +
                "the scooter must stop and lock");
        }

        [TestMethod]
        public void TestRunningOutBatteryChargeScooterLocked()
        {
            //Arrange
            Scooter testScooter = new Scooter();

            //Act
            testScooter.LockScooter();
            double previousCharge = testScooter.Charge;
            double previousHours = testScooter.Hours;
            bool previousBatteryStatus = testScooter.IsUnlocked();
            testScooter.Ride(15);

            //Assert
            Assert.AreEqual(testScooter.Charge, previousCharge, 0.01, "You cannot ride " +
                "because the scooter is locked");

            Assert.AreEqual(testScooter.Hours, previousHours, 0.01, "You cannot ride" +
                "because the scooter is locked");

            Assert.AreEqual(testScooter.IsUnlocked(), previousBatteryStatus,
                "Scooter locked - boolean should be IsUnlocked");
        }

        [TestMethod]
        public void TestRideOKValIncrementsScooterUnlocked()
        {
            //Arrange
            Scooter testScooter = new Scooter();

            //Act
            testScooter.UnlockScooter();
            testScooter.Ride(2);
            testScooter.Ride(1);

            //Assert
            Assert.AreEqual(testScooter.Charge, 190, 0.01, "Problem with formula " +
                "to update the battery level after driving, battery level should decrement");

            Assert.AreEqual(testScooter.Hours, 3, 0.01, "Problem with formula " +
                "to update hours, hours should increment");
        }

        [TestMethod]
        public void TestRideOKValIncrementsScooterLocked()
        {
            //Arrange
            Scooter testScooter = new Scooter();

            //Act
            testScooter.UnlockScooter();
            testScooter.LockScooter();
            double previousCharge = testScooter.Charge;
            double previousHours = testScooter.Hours;
            testScooter.Ride(2);
            testScooter.Ride(1);

            //Assert
            Assert.AreEqual(testScooter.Charge, previousCharge, 0.01, "You cannot ride " +
                "because the scooter is locked");

            Assert.AreEqual(testScooter.Hours, previousHours, 0.01, "You cannot ride" +
                "because the scooter is locked");
        }

        [TestMethod]
        public void TestInspectionScooterLocked()
        {
            //Arrange
            Scooter testScooter = new Scooter();

            //Act
            testScooter.UnlockScooter();
            testScooter.LockScooter();
            double previousHours = testScooter.Hours;
            testScooter.Inspect();

            //Assert
            Assert.AreEqual(testScooter.Hours, previousHours, 0.01, "The next inspection should be 48");
        }

        [TestMethod]
        public void TestInspectionScooterUnlocked()
        {
            //Arrange
            Scooter testScooter = new Scooter();

            //Act
            testScooter.UnlockScooter();
            double previousInspectionHours = testScooter.HoursNextSoftwareUpdate;
            testScooter.Inspect();

            //Assert
            Assert.AreEqual(previousInspectionHours, testScooter.HoursNextSoftwareUpdate,
                0.01, "The next inspection should be 48");
        }

        [TestMethod]
        public void TestUnlockScooter()
        {
            //Arrange
            Scooter testScooter = new Scooter();

            //Act
            testScooter.UnlockScooter();


            //Assert
            Assert.IsTrue(testScooter.IsUnlocked(), "When you unlock the scooter " +
                "the unlocked boolean should be true");
        }

        [TestMethod]
        public void TestLockScooter()
        {
            //Arrange
            Scooter testScooter = new Scooter();

            //Act
            testScooter.LockScooter();

            //Assert
            Assert.IsFalse(testScooter.IsUnlocked(), "When you stop the scooter " +
                "the unlocked boolean should be false");
        }
    }
}


