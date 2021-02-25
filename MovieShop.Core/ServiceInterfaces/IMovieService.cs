using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Core.Entities;
using MovieShop.Core.Models.Request;
using MovieShop.Core.Models.Response;

namespace MovieShop.Core.ServiceInterfaces
{
    public interface IMovieService
    {
        Task<MovieDetailsResponseModel> GetMovieById(int id);
        Task<IEnumerable<MovieCardResponseModel>> GetTop25GrossingMovies();
        Task<IEnumerable<MovieCardResponseModel>> GetMoviesByGenre(int genreId);
        Task<IEnumerable<ReviewMovieResponseModel>> GetReviewsForMovie(int id);
        Task<IEnumerable<MovieRatingResponseModel>> GetTopRatedMovies();
        Task<MovieDetailsResponseModel> CreateMovie(MovieCreateRequest movieCreateRequest);
    }
}
