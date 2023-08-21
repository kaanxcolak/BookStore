using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Command
{
    public class CreateAuthor
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateAuthorModel Model { get; set; }

        public CreateAuthor(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {

        }
        
    }
    public class CreateAuthorModel
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
