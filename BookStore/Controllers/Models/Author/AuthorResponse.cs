using FluentValidation;

namespace BookStore.Controllers.Models.Author
{
    public class AuthorResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    public class AuthorResponseValidator : AbstractValidator<AuthorResponse>
    {
       public AuthorResponseValidator()
        {
            RuleFor(a => a.FirstName).NotEmpty().MinimumLength(3);
            RuleFor(a => a.LastName).NotEmpty().MinimumLength(3);
        }
    }


}
