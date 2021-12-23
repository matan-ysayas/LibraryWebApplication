using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryWebApplication.Models
{
    public class Book
    {
        public string name;
        public string author;
        public int YearOfPublication;
        public int numOfPages;
        public int id;
      static  int counter = 0;

       public Book(string name,string author,int yearOfPublication,int numOfPages)
        {
            this.name = name;
            this.author = author;
            this.YearOfPublication = yearOfPublication;
            this.numOfPages = numOfPages;
            this.id = counter++;
        }



    }
}