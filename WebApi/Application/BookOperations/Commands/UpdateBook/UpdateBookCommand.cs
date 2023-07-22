using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int BookId { get; set; }
        public UpdateBookModel Model { get; set; }

        public UpdateBookCommand(BookStoreDbContext dbContext, IMapper _mapper)
        {
            _context = dbContext;
        }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null)
                throw new InvalidOperationException("Güncellenecek Kitap Bulunamadı!");
            book = _mapper.Map<Book>(Model);

            _context.SaveChanges();
            //_context.SaveChangesAsync();
        }

        public class UpdateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }

        }
    }
}
