namespace BookStore.Controllers.Models.Author
{
    public class FindAuthorQuery
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Page { get; set; }

        public int Limit { get; set; }
    }
}
