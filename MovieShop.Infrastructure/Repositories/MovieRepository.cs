using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieShop.Core.Entities;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Infrastructure.Data;

namespace MovieShop.Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Movie> GetTopRatedMovies()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetTopRevenueMovies()
        {
            return _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(20);
        }

        public override Movie GetByIdAsync(int id)
        {
            return _dbContext.Movies.FirstOrDefault(m => m.Id == id);
        }
    }
}
