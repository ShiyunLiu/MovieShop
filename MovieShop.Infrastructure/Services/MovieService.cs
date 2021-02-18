using System;
using System.Collections.Generic;
using System.Text;
using MovieShop.Core.Entities;
using MovieShop.Core.ServiceInterfaces;
using MovieShop.Infrastructure.Repositories;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.Models.Response;

namespace MovieShop.Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository; //Dependency Injection by constructor injection; why readonly: only change in declaration(inside constructor)
        //MovieService movieservice = new MovieService (); will not compile because we have a parameter(a class that implement IMovieRepository)
        //MovieService movieservice = new MovieService (new MovieRepository()); will compile becuase MovieRepository implements IMovieRepository
        public MovieService(IMovieRepository movieRepository) // Constructor with an Interface as parameter: pass a class that implement this Interface
        {
            _movieRepository = movieRepository; // 
        }

        public MovieDetailsResponseModel GetMovieById(int id)
        {
            var movieDetails = new MovieDetailsResponseModel();
            var movie = _movieRepository.GetByIdAsync(id);

            // map movie entity to MovieDetailsResponseModel
            movieDetails.Id = movie.Id;

            return movieDetails;
        }

        public IEnumerable<MovieCardResponseModel> GetTop25GrossingMovies()
        {
            var movies = _movieRepository.GetTopRevenueMovies();
            var movieCardResponseModel = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                var movieCard = new MovieCardResponseModel
                {
                    Id = movie.Id,
                    PosterUrl = movie.PosterUrl,
                    Revenue = movie.Revenue,
                    Title = movie.Title
                };
                movieCardResponseModel.Add(movieCard);

            }

            return movieCardResponseModel;
        }
    }
}