using FluentValidation;

namespace WebApi.Application.AuthorOperations.Command.CreateAuthor
{
    public class CreateAuthorValidator:AbstractValidator<CreateAuthor>
    {
        public CreateAuthorValidator()
        {
            RuleFor(x => x.Model.Name).MinimumLength(2).NotEmpty();
            RuleFor(x => x.Model.LastName).MinimumLength(2).NotEmpty();
            RuleFor(x=>x.Model.BookId).NotEmpty().GreaterThan(0);   
        }
    }
}
