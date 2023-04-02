using System;
using System.Collections.Generic;
using System.Text;

namespace ScooterProject
{
    class ScooterManager
    {
        static void Main(String[] args)
        {

            Console.WriteLine("**Testing starts");
            Scooter s = new Scooter("Bird", "Razor", 2019, 30.0);
            int errors = 0;
            Console.WriteLine("**Testing - constructor");
            Console.WriteLine(s.ToString());

            if (s.App.Equals("Bird"))
            {
                Console.WriteLine("app property is working");
            }
            else
            {
                errors++;
            }


            if (s.Model.Equals("Razor"))
            {
                Console.WriteLine("model property is working");

            }
            else
            {
                errors++;
            }
            if (s.Year == 2019)
            {
                Console.WriteLine("year property is working");
            }
            else
            {
                errors++;
            }
            if (s.Wph== 30.0)
            {
                Console.WriteLine("Wph property is working");
            }
            else
            {
                errors++;
            }
            Scooter sc = new ScooterProject.Scooter();

            if (sc.App.Equals("Spin"))
            {
                Console.WriteLine("default App property is working");
            }
            else
            {
                errors++;
            }
            if (sc.Model.Equals("SegwayES4"))
            {
                Console.WriteLine("default model property is working");

            }
            else
            {
                errors++;
            }
            if (sc.Year == 2021)
            {
                Console.WriteLine("default year property is working");
            }
            else
            {
                errors++;
            }
            if (sc.Wph == 20.0)
            {
                Console.WriteLine("default Wph property is working");
            }
            else
            {
                errors++;
            }
            sc.App = "new name";
            if (sc.App.Equals("new name"))
            {
                Console.WriteLine("app setter working");
            }
            else
            {
                errors++;
            }
            sc.Model = "new model";
            if (sc.Model.Equals("new model"))
            {
                Console.WriteLine("model setter working");
            }
            else
            {
                errors++;
            }
            sc.Year = 2020;
            if (sc.Year == 2020)
            {
                Console.WriteLine("year setter working");
            }
            else
            {
                errors++;
            }
            sc.Wph = 22.0;
            if (sc.Wph == 22.0)
            {
                Console.WriteLine("wattsPerHour setter working");
            }
            else
            {
                errors++;
            }
            Scooter sc1 = new ScooterProject.Scooter();
           
            sc1.ChargeBattery(50);
           
            if (sc1.Charge == 250)
            {
                Console.WriteLine("ChargeBattery working");
            }
            else {
                errors++;
            }
            sc1.UnlockScooter();
            sc1.Ride(2);
            if (sc1.Hours == 2)
            {
                Console.WriteLine("Ride hours working");
             }
             else
            {
            errors++;
              }
            if (sc1.Charge == 210)
            {
                Console.WriteLine("Ride charge working");
            }
            else
            {
                errors++;
            }
            

            Console.WriteLine("**Testing ends with " + errors + " errors");
                Console.ReadLine();
            }
        }
    }

