using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Core.Entities;
using MovieShop.Core.Models.Response;

namespace MovieShop.Core.ServiceInterfaces
{
    public interface IMovieService
    {
        Task<MovieDetailsResponseModel> GetMovieById(int id);
        Task<IEnumerable<MovieCardResponseModel>> GetTop25GrossingMovies();
        Task<IEnumerable<ReviewResponseModel>> GetReviewsForMovie(int id);
    }
}
