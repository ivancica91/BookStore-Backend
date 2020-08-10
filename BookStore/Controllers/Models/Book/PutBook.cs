namespace BookStore.Controllers.Models.Book
{
    public class PutBook
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public string ImageSrc { get; set; }
        public int AuthorId { get; set; }
    }
}
