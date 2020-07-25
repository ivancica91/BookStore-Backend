using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public string ImageSrc { get; set; }

    }
    //private void SearchByTitle(Book book, string bookTitle)
    //{
    //    if (!book.Title.Any() || string.IsNullOrWhiteSpace(bookTitle))
    //        return;

    //    book = book.Where()
    //}
    
}
       

        //public class Books
        //{
        //    public List<Book> List()
        //    {
        //        return new List<Book> { }
                
        //        .OrderBy(a => a.Title).ToList();
        //    }

        //    public List<Book> GetByTitleSubstring(string titleSubstring)
        //    {
        //        return List()
        //            .Where(a =>
        //            a.Title.IndexOf(titleSubstring, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
        //            .ToList();

        //    }



    
