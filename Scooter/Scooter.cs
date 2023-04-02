using System;
using static System.Console;
namespace ScooterProject

{
    public class Scooter
    {
        private String _app;
        private String _model;
        private int _year;
        private double _hours;
        private double _charge;
        private double _wph;
        private const double BatteryCapacity = 250.0;
        private int _hoursNextSoftwareUpdate;
        private const int HoursBetweenUpdates = 48;
        private double hoursPossible;
        private bool _isUnlocked;
        public Scooter()
        {
            _app = "Spin";
            _model = "SegwayES4";
            _year = 2021;
            _hours = 0.0;
            _wph = 20.0;
            _charge = BatteryCapacity;
            _hoursNextSoftwareUpdate = HoursBetweenUpdates;
            _isUnlocked = false;

        }
        public Scooter(string app, string model, int year, double wph)
        {
            _app = app;
            _model = model;
            _year = year;
            _wph = wph;
            _charge = BatteryCapacity;
            _hoursNextSoftwareUpdate = HoursBetweenUpdates;
            _isUnlocked = false;
        }
        public String App
        {
            get { return _app; }
            set { _app = value; }
        }
        public String Model
        {
            get { return _model; }
            set { _model = value; }
        }
        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }
        public double Wph
        {
            get { return _wph; }
            set { _wph = value; }
        }
        public double Charge
        {
            get { return _charge; }
            set { _charge = value; }
        }
        public double Hours
        {
            get { return _hours; }
            set { _hours = value; }
        }
        public int HoursNextSoftwareUpdate
        {
            get { return _hoursNextSoftwareUpdate; }
            set { _hoursNextSoftwareUpdate = value; }
        }
   

        public void ChargeBattery(double chargeAmt)
        {if (_isUnlocked == true)
            {
                WriteLine(_app + _model + _year + " must be locked to charge the battery.");
            }
        else { 
            if (chargeAmt < 0)
            {
                WriteLine(_app + _model + _year + " watts cannot be a negative number - Charge in Battery after being plugged in: " + _charge);
            }
            else
            {
                _charge += chargeAmt;
                if (_charge > BatteryCapacity)
                {
                    WriteLine(_app + _model + _year + " battery overcharged - Charge in Battery after being pluged in: " + _charge);
                    _charge = BatteryCapacity;
                }
                else WriteLine(_app + _model + _year + " added charge: " + chargeAmt + " - Charge in Battery after being plugged in: " +
                    _charge);
                {

                }
            }
            }
        }
        public void Ride(double rideHours)
        {
            if (_isUnlocked == false)
            {
                WriteLine(_app + _model + _year + " must be UNLOCKED to ride.");
            }
            else
            {
                hoursPossible = (_charge / _wph);
                if (rideHours < 0)
                {
                    WriteLine(_app + _model + _year + " watts cannot ride negative hours.");
                }
                else if (rideHours > hoursPossible)
                {
                    _charge = 0;
                    _hours = hoursPossible;
                    WriteLine(_app + _model + _year + " ran out of battery charge after riding " + hoursPossible + " hours.");

                }
                else
                {
                    _charge = _charge - (_wph * rideHours);
                    _hours = rideHours += _hours;
                    WriteLine(_app + _model + _year + " rode " + _hours);
                }
                if(_charge == 0)
                {
                    _isUnlocked = false;
                }
            }
        }
        public void Inspect()
        {
            if (_isUnlocked == true)
            {
                WriteLine(_app + _model + _year + " must be locked to inspect software.");
            }
            else
            {
                _hoursNextSoftwareUpdate = (int)(_hours + HoursBetweenUpdates);
                WriteLine(_app + _model + _year + " has been updated, next update is: " + _hoursNextSoftwareUpdate);
            }
        }
        public void CheckforUpdate()
        {
            if (_isUnlocked == true)
            {
                WriteLine(_app + _model + _year + " must be locked to check for software updates.");
            }
            else
            {
                if (HoursNextSoftwareUpdate == HoursBetweenUpdates)
                {
                    WriteLine(_app + _model + _year + " - It is time to update software.");
                }
                else
                {
                    WriteLine(_app + _model + _year + " - Scooter is OK, no need to update software.");
                }
            }
        }
        public override String ToString()
        {
            return String.Format("{0}" + " " + "{1}" + " " + "{2}" + " Hours: " + "{3:.0.0}" + " Battery charge: " + "{4:.00}",  _app, _model, _year, _hours, _charge);
        }
        public void UnlockScooter()
        {
            _isUnlocked = true;

        }
        public void LockScooter()
        {
            _isUnlocked = false;

        }
        public bool IsUnlocked()
        {
            if (_isUnlocked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private double CalcRange()
        {
            hoursPossible = (_charge / _wph);
            return hoursPossible;
        }
        private double ChargeNeededToFullyChargeBattery()
        {
            double ChargeNeeded = BatteryCapacity - this._charge;
            return ChargeNeeded;
        }
        public void SimulateMultiUserRides(int numberOfUsers)
        {
            for (int i = 1; i <= numberOfUsers; i++)
            {
                Random Random = new Random();
                CalcRange();
                int minsPossible = (int)hoursPossible * 60;
                int randInt = Random.Next(1, minsPossible);
                double randHours = (double)(randInt / 60);
                UnlockScooter();
                Ride(randHours);
                LockScooter();
                if (_charge == 0)
                {
                    WriteLine("number of users: " + i + "minutes went: " + minsPossible); 
                }
            }

        }
    }
}