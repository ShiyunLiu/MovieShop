using System;
using System.Collections.Generic;
using System.Text;
using MovieShop.Core.Entities;

namespace MovieShop.Core.RepositoryInterfaces
{
    public interface IMovieRepository : IAsyncRepository<Movie>
    {
        IEnumerable<Movie> GetTopRatedMovies();
        IEnumerable<Movie> GetTopRevenueMovies();
    }
}
