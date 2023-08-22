using FluentValidation;

namespace WebApi.Application.AuthorOperations.Command.DeleteAuthor
{
    public class DeleteAuthorValidator:AbstractValidator<DeleteAuthor>
    {
        public DeleteAuthorValidator()
        {
            RuleFor(x => x.AuthorID).GreaterThan(0);

        }

    }
}
