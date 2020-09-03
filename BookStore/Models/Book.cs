namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public string ImageSrc { get; set; }
        public int AuthorId { get; set; }
      
        public Author Author { get; set; }
    }
}




