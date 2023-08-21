using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;


namespace WebApi.Application.AuthorOperations.Queries
{
    public class GetAuthorDetailQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int AuthorId;
        public AuthorDetailViewModel Model;

        public GetAuthorDetailQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public AuthorDetailViewModel Handle()
        {
            var author = _dbContext.Authors.Include(x => x.Book).SingleOrDefault(x => x.ID == AuthorId);
            if (author == null)
                throw new InvalidOperationException("Yazar Bulunamadı!");

            AuthorDetailViewModel model = _mapper.Map<AuthorDetailViewModel>(author);
            return model;
        }
    }

    public class AuthorDetailViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Book { get; set; }

    }
}
