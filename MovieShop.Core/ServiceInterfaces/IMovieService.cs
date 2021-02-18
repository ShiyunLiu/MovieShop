using System;
using System.Collections.Generic;
using System.Text;
using MovieShop.Core.Entities;
using MovieShop.Core.Models.Response;

namespace MovieShop.Core.ServiceInterfaces
{
    public interface IMovieService
    {
        MovieDetailsResponseModel GetMovieById(int id);
        IEnumerable<MovieCardResponseModel> GetTop25GrossingMovies();
    }
}
