using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project7;

// Steven Nguyen
// Project 7 programm for a Meat Markets 

namespace Project7_SN
{
    class Program
    {
        const double FixedCost = 5.0;
        // Create a list for the different per ounce charge 
        static List<double> PerOunceCharge = new List<double>() {.05, .75, .06, .45};
        // Create a list for the different meat charges
        static List<string> zoneNames = new List<string>() { "Pork", "chicken", "lamb", "beef" };
            // Creat a list to be pulled from the class level
        static List<Package> OrderTheMeat = new List<Package>();
        static int menuoption; // create a variable to store menu option
        static int weight; // create a variable to store weight
            // Create a while loop to continually run program 


        static void Main(string[] args)
        {
            // Loop until exit
            while (true)
            {
                //  Hip Ship is a small shipping company that will transport your packages anywhere in Oklahoma. 
                // Display the options the user can select 1, 2, and 3.
                Console.WriteLine(
                    "1. Display the total revenue for meat\n2. Display weight for all packages for all meat\n3. Buy the meat");
                // Read the User Input
                string userinput = Console.ReadLine();
                // Use an if to Parse into an integer, and entry have to be 1, 2, 3, or 4.
                if (int.TryParse(userinput, out menuoption) && menuoption == 1)
                {
                    // Call Sum and Display Revenues by Zone method and call shippingPkgs
                    SumAndDisplayRevenueByZone(OrderTheMeat);
                }
                else if (int.TryParse(userinput, out menuoption) && menuoption == 2)
                {
                    SumAndDisplayWeightByZone(OrderTheMeat);
                }
                else if (int.TryParse(userinput, out menuoption) && menuoption == 3)
                {
                    ShipThepackage(OrderTheMeat);

                }

                // Else: if user enters any number outside 1, 2, 3 the console will display an error message
                else
                {
                    // Display an error message for an invalid input. Please select the number between 1 and 3.
                    Console.Write("Error! You entered a invalid input : Please select a number between 1 and 3.\n");
                }

            }
        }

        static private void ShipThepackage(List<Package> CalList)
        {
            
                    // User must select the zone where the package is being shipped, and the 
                    Console.WriteLine("Select the zone:\n1. Pork\n2. chicken\n3. lamb\n4. beef");
            //Read the user input
            string zoneInput = Console.ReadLine();
            int zoneIndex; // create a variable to store the soneIndex 
                           //Use an if to TryParse into an integer, and make sure it is greater than or equal to 1, and less than and equal to 4.
            if (int.TryParse(zoneInput, out zoneIndex) && zoneIndex >= 1 && zoneIndex <= 4)
            {
                // Index starts at 0 : must create this to get the user's input to coincide with the program correctly. 
                zoneIndex = zoneIndex - 1;
                // Display to user to enter weight fot this package in ounces.
                Console.WriteLine("Please enter the weight of this package in ounces?");
                string weightInput = Console.ReadLine(); // Read user's input.
                                                         // Tryparse the user's input and output weight if the entries are valid.
                if (int.TryParse(weightInput, out weight) && weight > 0)
                {
                    // Calculation for the charge here
                    double charge = FixedCost + PerOunceCharge[zoneIndex] * weight;

                    // Call Package constructor based on selected zone.
                    Package po = new Package(zoneNames[zoneIndex], charge, weight);
                    OrderTheMeat.Add(po);
                    // Display the cost of shipping your package is ...
                    Console.WriteLine("The cost of shipping your package is = " + charge.ToString("C") + "\n");
                }
                else
                {
                    // This is for invalid weight entry
                    Console.WriteLine(
                        "Error! Invalid weight entry : Package weight must be greater than 0 ounces.");
                }
            }
            else
            {
                // Display an error message for bad zone input
                Console.WriteLine("Error! You enter a bad zone input: Please select a zone between 1 thru 4.");
            }
        }
        // method to sum and display
            static private void SumAndDisplayRevenueByZone (List<Package> CalList)
            {
                double sumA = 0, sumB = 0, sumC = 0, sumD = 0;
                for (int i = 0; i < CalList.Count; i++)
                {
                    if (CalList[i].meat == "Pork")
                    {
                        sumA = sumA + CalList[i].Charge;
                    }
                    else if (CalList[i].meat == "chicken")
                    {
                        sumB = sumB + CalList[i].Charge;
                    }
                    else if (CalList[i].meat == "lamb")
                    {
                        sumC = sumC + CalList[i].Charge;
                    }
                    else
                    {
                        sumD = sumD + CalList[i].Charge;
                    }

                }

                // Display the Revenue sums for Zone A, B, C, D. Display the total revenue for the total revenue for all sums.
                Console.WriteLine("\nRevenue sum for Pork = " + sumA.ToString("C"));
                Console.WriteLine("Revenue sum for chicken = " + sumB.ToString("C"));
                Console.WriteLine("Revenue sum for lamb = " + sumC.ToString("C"));
                Console.WriteLine("Revenue sum for beef = " + sumD.ToString("C"));
                Console.WriteLine("\nYour total revenue is = " + (sumA + sumB + sumC + sumD).ToString("C"));
            }
            // end of method


            // method to sum and display
            static private void SumAndDisplayWeightByZone(List<Package> totalList)
            {
                double sumA = 0, sumB = 0, sumC = 0, sumD = 0;

                for (int i = 0; i < totalList.Count; i++)
                {
                    if (totalList[i].meat == "Pork")
                    {
                        sumA = sumA + totalList[i].Weight;
                    }
                    else if (totalList[i].meat == "chicken")
                    {
                        sumB = sumB + totalList[i].Weight;
                    }
                    else if (totalList[i].meat == "lamb")
                    {
                        sumC = sumC + totalList[i].Weight;
                    }
                    else
                    {
                        sumD = sumD + totalList[i].Weight;
                    }
                }

                // Display the weight sum for Zone A, B, C, and D. Display the total weight for all sums.
                Console.WriteLine("The Weight sum for Pork = " + sumA.ToString());
                Console.WriteLine("The Weight sum for chicken = " + sumB.ToString());
                Console.WriteLine("The Weight sum for lamb = " + sumC.ToString());
                Console.WriteLine("The Weight sum for beef= " + sumD.ToString());
                Console.WriteLine("\nThe total weight for your package/s is/are = " +
                                  (sumA + sumB + sumC + sumD).ToString());
            } // end of method


        }
    }

