using System;
using System.Collections.Generic;
using System.IO;
namespace large_group_project


{
    class Program
    //Programmer Names: Singi Bowen, Yoshi Johnson, Clinton, Lawson, Steven Nguyen, and Denny Vu
    //Date created: April 25, 2017
    //Purpose of Progam: To create a Book inventory that displays to the user what books we have in stock to sell. Allow the us to sell the number of books
    //to user based off the quantity needed. Finally, to update our inventory and display what is left after sell.
    {
        //Created lists to hold the Book title, ISBN, Stock, Author Name, and Price

        static List<Book> Inventory = new List<Book>();
        static void Main(string[] args)
        {
            //This while loop was created to hold the users book selection. As long as the selection is valid it will continue to ask the user
         //what book they want and how much they want
         //Constant to input tax when books are sold

            const double Tax = .0875;

            //We are copying the contents of BooksInventory to Output since we must read from the Output file.
            //Once the application is closed, the file will not update, but only when the application is opened the next time.

            

            ReadInfo();
            {
                //Display the Book inventory to seller so that we are able to see what is currently in the inventory to sell
                DisplayInventory(Inventory);

                SumAndDisplayValueOfInventory(Inventory);

                Console.WriteLine("Select a book...");
                int menuSelect;
                string userInput = Console.ReadLine();

                //IF THE USER INPUT IS VALID USING TRYPARSE && CHECK THE INVENTORY RANGE
                if (int.TryParse(userInput, out menuSelect) && menuSelect >= 0 && menuSelect <= 6)
                {
                    //YOUR SELECTION IS ...
                    Console.WriteLine("Book choice:  " + Inventory[menuSelect]);
                    //PROMT USER TO ENTER ROOM WIDTH
                    Console.WriteLine("Quantity purchasing: ");
                    int total_quantity;
                    string quantity = Console.ReadLine();
                    if (int.TryParse(quantity, out total_quantity) && total_quantity > 0)
                    {

                        double total = Inventory[menuSelect].Price(total_quantity, Tax);
                        //DISPLAY TOTAL PRICE TO USER
                        Console.WriteLine("Total amount: " + total.ToString("C"));
                        Console.WriteLine("Confirm selection: Y / N");
                        string userYes = Console.ReadLine();
                        userYes = userYes.ToUpper().Substring(0, 1);
                        if (total_quantity <= Inventory[menuSelect].remainingBook && Inventory[menuSelect].SellBooks(total_quantity) && userYes == "Y")
                        {
                            //DISPLAY MESSAGE FOR SUCCESSFUL SALE
                            Console.WriteLine("Thank you...");
                            //DISPLAY UPDATED INVENTORY
                            Console.WriteLine("Inventory status: ");
                            DisplayInventory(Inventory);
                            SumAndDisplayValueOfInventoryAferPurchase(Inventory, total);
                            writefile(Inventory);
                        }
                        else
                        {
                            //ERROR PROCESSING FOR SALE
                            if (userYes != "Y")
                            {
                                //DISPLAY MESSAGE FOR UNSUCCESSFUL SALE
                                Console.WriteLine("Thank you for saving trees...");
                            }

                            else
                            {
                                //ERROR FOR NOT ENOUGH IN INVENTORY
                                Console.WriteLine("Inventory supply is too low...");
                            }
                        }

                    }
                    else
                    {
                        //ERROR FOR INVALID WIDTH
                        Console.WriteLine("Invalid input...");
                    }
                }
                else
                {
                    //ERROR FOR INVALID MENU SELECTION
                    Console.WriteLine("Invalid input, application will now close...");
                }

                //Copies the text files to keep them updated so you can use either one just by changing the name. 
                copy_inventory();
                //PRESS ENTER TO END
                Console.WriteLine("Close the application...");
                Console.ReadLine();

            }
        }

        static void copy_inventory()
        {

            string content = File.ReadAllText("BooksInventory.txt");
            File.WriteAllText("Output.txt", content);

        }

        //Writes to the BooksInventory file Output file if you change the names
        static void writefile(List<Book> bookInv)
        {
            StreamWriter bk = new StreamWriter("BooksInventory.txt");  //output file
            if (!System.IO.File.Exists("BooksInventory.txt"))
            {
                throw new FileNotFoundException();
            }
            for (int i = 0; i < Inventory.Count; i++)
            {
                bk.WriteLine(Inventory[i].tiltleOfBook);
                bk.WriteLine(Inventory[i].nameOfISBN);
                bk.WriteLine(Inventory[i].remainingBook);
                bk.WriteLine(Inventory[i].nameOfAuthor);
                bk.WriteLine(Inventory[i].bookPrice);

            }
            bk.Close();
        }



        //Reads from the BooksInventory file or the Output file if you change the names
        public static bool ReadInfo()
        {

            try
            {
                string title, ISBN, author;
                int qty;
                double price;
                StreamReader sw = new StreamReader("BooksInventory.txt");

                while (sw.Peek() > 0)
                {
                    title = sw.ReadLine();
                    ISBN = (sw.ReadLine());
                    qty = (Convert.ToInt32(sw.ReadLine()));
                    author = sw.ReadLine();
                    price = Convert.ToDouble(sw.ReadLine());
                    Book newBook = new Book(qty, ISBN, author, title, price);
                    Inventory.Add(newBook);
                }
                sw.Close();
                return true;



            }
            //If file is missing from location it will throw this error
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Absent file..." + ex.Message);
                return false;
            }
            //Also if the user type in an error second catch and this error message will show
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.GetType() + "\nError: " + ex.Message);
                return false;
            }

        }
        static private void DisplayInventory(List<Book> Inventory)
        {
            //DISPLAY A NUMBER THEN AN INVENTORY ITEM IN A LOOP
            for (int i = 0; i < Inventory.Count; i++)
            {
                Console.WriteLine(i + ": " + Inventory[i].ToString());
            }
        }//END METHOD TO DISPLAY INVENTORY

        static private void SumAndDisplayValueOfInventory(List<Book> myList)
        {
            double sum = 0;
            for (int i = 0; i < myList.Count; i++)
            {
                sum = (myList[0].remainingBook * myList[0].bookPrice)
                    + (myList[1].remainingBook * myList[1].bookPrice)
                    + (myList[2].remainingBook * myList[2].bookPrice)
                    + (myList[3].remainingBook * myList[3].bookPrice)
                    + (myList[4].remainingBook * myList[4].bookPrice)
                    + (myList[5].remainingBook * myList[5].bookPrice)
                    + (myList[6].remainingBook * myList[6].bookPrice);
            }


            Console.WriteLine("Inventory value: " + sum.ToString("C"));
        } // end of method
        static private void SumAndDisplayValueOfInventoryAferPurchase(List<Book> myList, double purchase)
        {

            double sum = 0;
            for (int i = 0; i < myList.Count; i++)
            {
                sum = (myList[0].remainingBook * myList[0].bookPrice)
                    + (myList[1].remainingBook * myList[1].bookPrice)
                    + (myList[2].remainingBook * myList[2].bookPrice)
                    + (myList[3].remainingBook * myList[3].bookPrice)
                    + (myList[4].remainingBook * myList[4].bookPrice)
                    + (myList[5].remainingBook * myList[5].bookPrice)
                    + (myList[6].remainingBook * myList[6].bookPrice);

            }
            double afterValue = sum - purchase;
            Console.WriteLine("Inventory value: " + afterValue.ToString("C"));


        } // end of method


    }
}

