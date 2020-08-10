using System.Collections.Generic;

namespace BookStore.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Book> Books { get; } = new List<Book>(); //zasto ovdje ovako, ne samo get set?
    }
}
