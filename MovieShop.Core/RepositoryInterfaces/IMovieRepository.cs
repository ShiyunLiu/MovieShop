using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Core.Entities;
using MovieShop.Core.Models.Response;

namespace MovieShop.Core.RepositoryInterfaces
{
    public interface IMovieRepository : IAsyncRepository<Movie>
    {
        Task<IEnumerable<MovieRatingResponseModel>> GetTopRatedMovies();
        Task<IEnumerable<Movie>> GetTopRevenueMovies();
        Task<IEnumerable<Review>> GetMovieReviews(int id);
        Task<IEnumerable<Purchase>> GetMoviePurchases(int id);
        Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId);
        Task<Movie> GetMovieByTitle(string movieTitle);
    }
}
