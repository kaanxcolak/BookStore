﻿using AutoMapper;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public int GenreId { get; set; }
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;
        private IBookStoreDbContext context;
        private IMapper mapper;

        public GetGenreDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetGenreDetailQuery(IBookStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.IsActive && x.Id == GenreId);
            if (genre is null)
                throw new InvalidOperationException("Kitap türü bulunamadı!");
            return _mapper.Map<GenreDetailViewModel>(genre);

        }

    }

    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
