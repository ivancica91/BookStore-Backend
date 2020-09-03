﻿namespace BookStore.Controllers.Models.Book
{
    public class PostBook
    {
        public int? AuthorId { get; set; }

        public string AuthorFullName {get; set;}
        public string Title { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public string ImageSrc { get; set; }
    }
}
