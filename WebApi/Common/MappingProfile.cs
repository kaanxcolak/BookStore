using AutoMapper;
using WebApi.Entities;
using static WebApi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using static WebApi.Application.BookOperations.Queries.GetBookDetail.GetBookDetailQuery;
using static WebApi.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;

namespace WebApi.Common
{
    public class MappingProfile:Profile  //automapper tarafından configur dosyası olarak görülecek kalıtım yaptığımız için
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();   //CreateBookModel objesi Book objesine maplenebilir demiş olduk ve ilk source, ikinci kısım target
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<UpdateBookModel, Book >();
            CreateMap<Genre, GenresViewModel>(); 
            CreateMap<Genre, GenreDetailViewModel>(); 
        }
    }
}
