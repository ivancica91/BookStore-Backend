using FluentValidation;

namespace BookStore.Controllers.Models.Book
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

    public class PostBookValidator : AbstractValidator<PostBook>
    {
        public PostBookValidator()
        {
            RuleFor(b => b.AuthorFullName).NotEmpty();
            RuleFor(b => b.Condition).NotEmpty();
            RuleFor(b => b.Description).NotEmpty();
            RuleFor(b => b.ImageSrc).NotEmpty();
            RuleFor(b => b.Price).GreaterThanOrEqualTo(5);
            RuleFor(b => b.Title).NotEmpty();

        }
    }
}
