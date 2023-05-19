using Microsoft.AspNetCore.Mvc;

namespace WebApi.AddControllers{

    [ApiController]
    [Route("[controller]/[action]")]
    public class BookController:ControllerBase
    {
        //static yaptık çünkü uygulama çalıştığı sürece yaşamalı ve uygulama sona erince lifecycle sonra ermeli!
        private static List<Book> BookList = new List<Book>()
        {
            new Book{
                Id =1,
                Title = "Lean Startup",
                GenreId = 1, //Personal Growth
                PageCount = 200,
                PublishDate = new DateTime(2001,04,02)
            },
            new Book{
                Id =2,
                Title = "Herland",
                GenreId = 2, //Science Fiction
                PageCount = 250,
                PublishDate = new DateTime(2011,04,22)
            },
            new Book{
                Id =3,
                Title = "Dune",
                GenreId = 2, //Science Fiction 
                PageCount = 500,
                PublishDate = new DateTime(2021,01,12)
            },
        }; //static liste kapandı


        [HttpGet]
        public List<Book> GetBooks()                //Linq ile sql ifadelerini kullanabildik
        {
            var bookList = BookList.OrderBy(x => x.Id).ToList<Book>();
            return bookList;
        }

        [HttpGet("{id}")]
        public Book GetByID(int id)                //Linq ile sql ifadelerini kullanabildik
        {
            var book = BookList.Where(book => book.Id ==id).SingleOrDefault();
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
        public IActionResult AddBook([FromBody] Book newBook)
        {
            var book = BookList.SingleOrDefault(x=>x.Title == newBook.Title);
            if(book is not null)
            return BadRequest();

            BookList.Add(newBook);
            return Ok();

        }
        //Put  --> Update yapar
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updateBook)    //IActionResult ile validation yapmış oluruz yoksa hata döndürür
        {
            var book = BookList.SingleOrDefault(x => x.Id == id);
            if(book is null)
                return BadRequest();
            book.GenreId = updateBook.GenreId != default ? updateBook.GenreId : book.GenreId;
            book.PageCount = updateBook.PageCount != default ? updateBook.PageCount : book.PageCount;
            book.PublishDate = updateBook.PublishDate != default ? updateBook.PublishDate : book.PublishDate;
            book.Title = updateBook.Title != default ? updateBook.Title : book.Title;
            return Ok();            
        }      

        //Delete
        [HttpDelete("id")]
        public IActionResult       


    }
}