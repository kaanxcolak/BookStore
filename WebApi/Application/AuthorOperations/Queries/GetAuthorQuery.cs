using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Queries
{
    public class GetAuthorQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAuthorQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<AuthorViewModel> Handle()
        {
            var authors = _dbContext.Authors.OrderBy(x => x.ID).ToList();
            List<AuthorViewModel> values = _mapper.Map<List<AuthorViewModel>>(authors);
            return values;
        }
    }

    public class AuthorViewModel
    {
        public string Name { get; set; }
        public string  LastName { get; set; }   
        public DateTime DateOfBirth { get; set; }

    }
}
