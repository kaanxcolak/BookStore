using FluentValidation;

namespace WebApi.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>  //createbookCommand nesnelerini valide eder
    {
        public CreateBookCommandValidator()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
            RuleFor(command => command.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.Title).MinimumLength(4);
        }

    }
}
