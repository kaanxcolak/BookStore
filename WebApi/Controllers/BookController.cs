using Microsoft.AspNetCore.Mvc;

namespace WebApi.AddControllers{

    [ApiController]
    [Route("{controller}s")]
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

    }
}