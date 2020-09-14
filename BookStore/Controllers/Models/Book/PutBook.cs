namespace BookStore.Controllers.Models.Book
{
    public class PutBook
    {
        public int? AuthorId { get; set; }

        public string AuthorName { get; set; } // mozda, kao i AuthorId
        public string Title { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public string ImageSrc { get; set; }

    }
}
