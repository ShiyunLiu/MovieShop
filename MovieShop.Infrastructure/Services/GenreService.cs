using MovieShop.Core.Entities;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly IAsyncRepository<Genre> _genreRepository;
        public GenreService(IAsyncRepository<Genre> genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public IEnumerable<Genre> GetAllGenres()
        {
            var genres = _genreRepository.ListAllAsync();
            return genres;
        }
    }
}
