using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using WebApi.DBOperations;
using static WebApi.Application.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.Application.BookOperations.GetBookDetail.GetBookDetailQuery;
using static WebApi.Application.BookOperations.UpdateBook.UpdateBookCommand;
using FluentValidation;
using WebApi.Application.BookOperations.CreateBook;
using WebApi.Application.BookOperations.DeleteBook;
using WebApi.Application.BookOperations.GetBookDetail;
using WebApi.Application.BookOperations.GetBooks;
using WebApi.Application.BookOperations.UpdateBook;

namespace WebApi.AddControllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context; //readonly olmasıyla sadece constructor içerisinde setleyebiliriz. 
        private readonly IMapper _mapper;


        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()                //Linq ile sql ifadelerini kullanabildik
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)                //Linq ile sql ifadelerini kullanabildik
        {
            BookDetailViewModel result;
            GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
            query.BookId = id;
            GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
            validator.ValidateAndThrow(query);

            result = query.Handle();

            return Ok(result);
        }


        // [HttpGet]
        // public Book Get ([FromQuery] string id)                //Linq ile sql ifadelerini kullanabildik
        // {
        //     var book = BookList.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
        //     return book;
        // }

        //Post --> Ekleme yapar
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = newBook;
            CreateBookCommandValidator validator = new CreateBookCommandValidator(); //instance oluşturdum!
            validator.ValidateAndThrow(command);
            command.Handle();

            //if (!result.IsValid)
            //    foreach (var item in result.Errors)
            //        Console.WriteLine("Özellik" + item.PropertyName + "- Error Message: " + item.ErrorMessage);
            //else
            //    command.Handle();


            return Ok();

        }
        //Put  --> Update yapar
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)    //IActionResult ile validation yapmış oluruz yoksa hata döndürür
        {
            UpdateBookCommand command = new UpdateBookCommand(_context, _mapper);
            command.BookId = id;
            command.Model = updatedBook;

            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        //Delete
        [HttpDelete("id")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookId = id;
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }


    }
}