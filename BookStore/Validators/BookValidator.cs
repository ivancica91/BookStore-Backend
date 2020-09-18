using BookStore.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(b => b.Condition).NotEmpty();
            RuleFor(b => b.Description).NotEmpty();
            RuleFor(b => b.ImageSrc).NotEmpty();
            RuleFor(b => b.Price).GreaterThanOrEqualTo(5);
            RuleFor(b => b.Title).NotEmpty();

        }
    }
}
