using LibraryWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LibraryWebApplication.Controllers.api
{
    public class BookController : Controller
    {

        List<Book> bookList = new List<Book>();
        Random random = new Random();
        public List<Book> pop()
        {
            bookList.Add(new Book("hobit", "bob", 1995, random.Next(100, 500)));
            bookList.Add(new Book("harry poter", "rob", 2002, random.Next(100, 500)));
            bookList.Add(new Book("mike", "avner", 1996, random.Next(100, 500)));
            bookList.Add(new Book("matan", "jorge", 2000, random.Next(100, 500)));
            bookList.Add(new Book("yosi", "corry", 1993, random.Next(100, 500)));
            bookList.Add(new Book("erer", "marcos", 1988, random.Next(100, 500)));
            bookList.Add(new Book("ermi", "dsds", 1985, random.Next(100, 500)));
            bookList.Add(new Book("bill", "erre", 2019, random.Next(100, 500)));

            return bookList;
        }


        // GET: Book
        public ActionResult Index()
        {
            return Json(pop(), JsonRequestBehavior.AllowGet);
        }

        // GET: Book/Details/5
        public ActionResult GetById(int id)
        {
            pop();
            Book bookId=bookList.Find(item=>item.id==id);
            if (bookId != null)
            {
                return Json(bookId, JsonRequestBehavior.AllowGet);
            }
            return Json("book not found",JsonRequestBehavior.AllowGet);
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                bookList.Add(
                    new Book(collection["name"], collection["author"], int.Parse(collection["YearOfPublication"]), int.Parse(collection["numOfPages"])));


                return Json("item was crate", JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("not succefully", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPut]
        public ActionResult Update(int id, Book book)
        {
            pop();
            try
            {
                foreach (Book bookItem in bookList)
                {
                    if (bookItem.id == id)
                    {
                        bookItem.name = book.name;
                        bookItem.author = book.author;
                        bookItem.YearOfPublication = book.YearOfPublication;
                        bookItem.numOfPages = book.numOfPages;
                    }
                    return Json("book edited succefully", JsonRequestBehavior.AllowGet);
                }
                return Json("book not edited", JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("book not edited", JsonRequestBehavior.AllowGet);
            }

        }


        // POST: Book/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            pop();
            try
            {

                foreach (Book book in bookList)
                {
                    if (book.id == id)
                    {
                        bookList.Remove(book);
                        return Json("book removed succefully", JsonRequestBehavior.AllowGet);
                    }

                }
                return Json("book not removed", JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("book not removed", JsonRequestBehavior.AllowGet);
            }
        }
        List<Book> nameBook = new List<Book>();
        public ActionResult GetByname(string name)
        {
            pop();
            try
            {
                
                foreach(Book book in bookList)
                {
                    if(book.name == name)
                    {
                        nameBook.Add(book);
                    }

                }
                return Json(nameBook, JsonRequestBehavior.AllowGet);  
            }
            catch
            {
                return Json("book not exist", JsonRequestBehavior.AllowGet);
            }
            




            
        }



    } 
}
