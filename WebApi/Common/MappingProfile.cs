using AutoMapper;
using WebApi.BookOperations.GetBooks;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.GetBookDetail.GetBookDetailQuery;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;

namespace WebApi.Common
{
    public class MappingProfile:Profile  //automapper tarafından configur dosyası olarak görülecek kalıtım yaptığımız için
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();   //CreateBookModel objesi Book objesine maplenebilir demiş olduk ve ilk source, ikinci kısım target
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<UpdateBookModel, Book >();
        }
    }
}
