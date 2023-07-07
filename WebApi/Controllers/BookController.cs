using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBooks;
using WebApi.DBOperations;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace WebApi.AddControllers{

    [ApiController]
    [Route("[controller]/[action]")]
    public class BookController:ControllerBase
    {
        private readonly BookStoreDbContext _context; //readonly olmasıyla sadece constructor içerisinde setleyebiliriz. 

        public BookController(BookStoreDbContext context)
        {
            _context = context; 

        }

        [HttpGet]
        public IActionResult GetBooks()                //Linq ile sql ifadelerini kullanabildik
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public Book GetByID(int id)                //Linq ile sql ifadelerini kullanabildik
        {
            var book = _context.Books.Where(book => book.Id ==id).SingleOrDefault();
            return book;
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
            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);   
            }          
         

            return Ok();

        }
        //Put  --> Update yapar
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updateBook)    //IActionResult ile validation yapmış oluruz yoksa hata döndürür
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if(book is null)
                return BadRequest();
            book.GenreId = updateBook.GenreId != default ? updateBook.GenreId : book.GenreId;
            book.PageCount = updateBook.PageCount != default ? updateBook.PageCount : book.PageCount;
            book.PublishDate = updateBook.PublishDate != default ? updateBook.PublishDate : book.PublishDate;
            book.Title = updateBook.Title != default ? updateBook.Title : book.Title;

            _context.SaveChanges();
            return Ok();            
        }      

        //Delete
        [HttpDelete("id")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.SingleOrDefault(x=>x.Id == id);
            if(book is null)
                return BadRequest();

            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();

        }       


    }
}