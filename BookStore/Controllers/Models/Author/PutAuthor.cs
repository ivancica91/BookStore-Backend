using FluentValidation;

namespace BookStore.Controllers.Models.Author
{
    public class PutAuthor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class PutAuthorValidator : AbstractValidator<PutAuthor>
    {
        public PutAuthorValidator()
        {
            RuleFor(a => a.FirstName).NotEmpty();
            RuleFor(a => a.LastName).NotEmpty();
        }
    }
}
