namespace BookStore.Controllers.Models.Book
{
    public class PutBook
    {
        public int AuthorId { get; set; }
        ///public int Id { get; set; }

        //public string AuthorFullName
        //{
        //    get; set;   //zbog edita, mozda treba i obrisat
        //}
        public string Title { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public string ImageSrc { get; set; }

         public BookAuthor Author { get; set; }

    }
}
