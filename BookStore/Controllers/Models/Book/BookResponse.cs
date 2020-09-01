﻿namespace BookStore.Controllers.Models
{
    public class BookResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public BookAuthor Author { get; set; }
        public string ImageSrc { get; set; }
        public int Price { get; set; }

        public string Description { get; set; }
        public string Condition { get; set; }
    }

    public class BookAuthor
    {
        public int Id { get; set; }

        public string FullName { get; set; }
    }
}
