using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookStore.Controllers.Models
{
    public class BookById
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public string ImageSrc { get; set; }
        public Name Author { get; set; }

    }

    public class Name
    {
        public int Id { get; set; }
        public string FirstLastName { get; set; }

    }
}





