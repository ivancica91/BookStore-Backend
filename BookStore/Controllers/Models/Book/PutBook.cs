using FluentValidation;

namespace BookStore.Controllers.Models.Book
{
    public class PutBook
    {
        public int? AuthorId { get; set; }

        public string AuthorName { get; set; } 
        public string Title { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public string ImageSrc { get; set; }

    }

    public class PutBookValidator : AbstractValidator<PutBook>
    {
        public PutBookValidator()
        {
            RuleFor(b => b.AuthorName).NotEmpty();
            RuleFor(b => b.Condition).NotEmpty();
            RuleFor(b => b.Description).NotEmpty();
            RuleFor(b => b.ImageSrc).NotEmpty();
            RuleFor(b => b.Price).GreaterThanOrEqualTo(5);
            RuleFor(b => b.Title).NotEmpty();

        }
    }
}
