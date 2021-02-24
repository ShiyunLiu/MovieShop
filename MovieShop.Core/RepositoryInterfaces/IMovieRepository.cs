using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Core.Entities;

namespace MovieShop.Core.RepositoryInterfaces
{
    public interface IMovieRepository : IAsyncRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetTopRatedMovies();
        Task<IEnumerable<Movie>> GetTopRevenueMovies();
        Task<IEnumerable<Review>> GetMovieReviews(int id);
        Task<IEnumerable<Purchase>> GetMoviePurchases(int id);
    }
}
