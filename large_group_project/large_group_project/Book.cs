using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace large_group_project
{//Book class created to hold all the information needed to create the book inventory
    class Book
    {
        public string tiltleOfBook;
        public string nameOfISBN;
        public int remainingBook;
        public int soldTBooks;
        public string nameOfAuthor;
        public double bookPrice;
        // This public property holds all the information that is available on the book. This information is then used to display
        //to the purchaser the type (name) of books we have inventory, name of author, and price
        public Book(int totalOfBook, string NewOfISBN, string newNameOfAuthor, string NewTiltleOfBook, double newbookPrice)
        {
            remainingBook = totalOfBook;
            TiltleOfBook = NewTiltleOfBook;
            soldTBooks = 0;
            bookPrice = newbookPrice;
            nameOfISBN = NewOfISBN;
            nameOfAuthor = newNameOfAuthor;
        }
        //The following get sets are properties of the books in the inventory that will later allow for the
        //display of the remaining books with the following information: name of author, isbn, title of book 
        //and goes through the list in order to get information
        public int RemainingBook
        {
            get
            {
                return remainingBook;
            }
        }
        public string NameOfAuthor
        {
            get
            {
                return nameOfAuthor;
            }
        }
        public string NumberOfISBN
        {
            get
            {
                return nameOfISBN;
            }
        }
        public string TiltleOfBook
        {
            get
            {
                return tiltleOfBook;
            }
            set
            {
                if (value.Length > 0)
                {
                    tiltleOfBook = value;
                }
                else
                {
                    throw new Exception("Invalid book title...");
                }
            }
        }
        public bool IsEqual(string searchBook)
        {
            if (searchBook == tiltleOfBook)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SellBooks(int qty)
        {
            if (remainingBook >= qty)
            {
                remainingBook = RemainingBook - qty;
                return true;
            }
            else
            {
                return false;
            }
        }

        public double Price(int qty, double tax)
        {
            return (bookPrice * qty) + (1 * tax);
        }
        public override string ToString()
        {
            string msg = tiltleOfBook + ", " + "\n\t by " + nameOfAuthor + "" + "\n\t " + RemainingBook.ToString() + " books in stock " +
                "\n\t " + bookPrice.ToString("C") + " / item";
            return msg;
        }
    }
}
