using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7
{
    class Package
    {
        // Your solution must use a package class that stores the zone, charge, and weight of the packages.
        string zone;
        double charge;
        int weight;
        // Public Constructor
        public Package(string newMeat, Double newCharge, int newWeight)
        {
            meat = newMeat;
            Charge = newCharge;
            Weight = newWeight;
        }
        // Public Properties
        public string meat
        {
            get { return zone; }
            set
            {
                if (value == "Pork" || value == "chicken" || value == "lamb" || value == "beef")
                {
                    zone = value;
                }
                else
                {
                    throw new Exception("Invalid package zone value of " + value);
                }
            }
        }// end public property zone
        public double Charge
        {
            get { return charge; }
            set
            {
                if (value > 5.0)
                {
                    charge = value;
                }
                else
                {
                    throw new Exception("Invalid package charge value of " + value.ToString("C"));
                }
            }
        }
        public int Weight
        {
            get { return weight; }
            set
            {
                if (value > 0)
                {
                    weight = value;
                }
                else
                {
                    throw new Exception("Invalid package weight value of " + weight);
                }
            }
        }
    }
}
