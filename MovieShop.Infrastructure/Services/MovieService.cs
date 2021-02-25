using System;
using System.Collections.Generic;
using System.Text;
using MovieShop.Core.Entities;
using MovieShop.Core.ServiceInterfaces;
using MovieShop.Infrastructure.Repositories;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.Models.Response;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;
using MovieShop.Core.Models.Request;

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

        public async Task<MovieDetailsResponseModel> CreateMovie(MovieCreateRequest movieCreateRequest)
        {
            var dbMovie = await _movieRepository.GetMovieByTitle(movieCreateRequest.Title);
            if (dbMovie != null && string.Equals(dbMovie.Title, movieCreateRequest.Title, StringComparison.CurrentCultureIgnoreCase))
                throw new Exception("Movie Already Exits");

            var movie = new Movie
            {
                Id = movieCreateRequest.Id,
                Title = movieCreateRequest.Title,
                PosterUrl = movieCreateRequest.PosterUrl,
                BackdropUrl = movieCreateRequest.BackdropUrl,
                //Rating = movie.Rating,
                Overview = movieCreateRequest.Overview,
                Tagline = movieCreateRequest.Tagline,
                Budget = movieCreateRequest.Budget,
                Revenue = movieCreateRequest.Revenue,
                ImdbUrl = movieCreateRequest.ImdbUrl,
                TmdbUrl = movieCreateRequest.TmdbUrl,
                ReleaseDate = movieCreateRequest.ReleaseDate,
                RunTime = movieCreateRequest.RunTime,
                Price = movieCreateRequest.Price
            };
            var createMovie = await _movieRepository.AddAsync(movie);
            var response = new MovieDetailsResponseModel
            {
                Id = createMovie.Id,
                Title = createMovie.Title,
                PosterUrl = createMovie.PosterUrl,
                BackdropUrl = createMovie.BackdropUrl,
                //Rating = movie.Rating,
                Overview = createMovie.Overview,
                Tagline = createMovie.Tagline,
                Budget = createMovie.Budget,
                Revenue = createMovie.Revenue,
                ImdbUrl = createMovie.ImdbUrl,
                TmdbUrl = createMovie.TmdbUrl,
                ReleaseDate = createMovie.ReleaseDate,
                RunTime = createMovie.RunTime,
                Price = createMovie.Price
            };
            return response;
        }

        public async Task<MovieDetailsResponseModel> GetMovieById(int id)
        {
            var movieDetails = new MovieDetailsResponseModel();
            var movie = await _movieRepository.GetByIdAsync(id);

            // map movie entity to MovieDetailsResponseModel
            movieDetails.Id = movie.Id;
            movieDetails.PosterUrl = movie.PosterUrl;
            movieDetails.Title = movie.Title;
            movieDetails.Overview = movie.Overview;
            movieDetails.Tagline = movie.Tagline;
            movieDetails.Budget = movie.Budget;
            movieDetails.Revenue = movie.Revenue;
            movieDetails.ImdbUrl = movie.ImdbUrl;
            movieDetails.TmdbUrl = movie.TmdbUrl;
            movieDetails.BackdropUrl = movie.BackdropUrl;
            movieDetails.OriginalLanguage = movie.OriginalLanguage;
            movieDetails.ReleaseDate = movie.ReleaseDate;
            movieDetails.RunTime = movie.RunTime;
            movieDetails.Price = movie.Price;

            movieDetails.Genres = new List<GenreModel>();
            movieDetails.Casts = new List<CastResponseModel>();

            foreach (var genre in movie.Genres)
            {
                movieDetails.Genres.Add(new GenreModel { Id = genre.Id, Name = genre.Name });
            }

            foreach (var cast in movie.MovieCasts)
            {
                movieDetails.Casts.Add(new CastResponseModel
                {
                    Id = cast.CastId,
                    Character = cast.Character,
                    Name = cast.Cast.Name,
                    ProfilePath = cast.Cast.ProfilePath
                });
            }

            return movieDetails;
        }

        public async Task<IEnumerable<MovieCardResponseModel>> GetMoviesByGenre(int genreId)
        {
            var movies = await _movieRepository.GetMoviesByGenre(genreId);
            if (!movies.Any())
                throw new Exception("No Movies Found");
            var response = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                response.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl,
                    Revenue = movie.Revenue
                });
            }
            return response;
        }

        public async Task<IEnumerable<ReviewMovieResponseModel>> GetReviewsForMovie(int id)
        {
            var reviews = await _movieRepository.GetMovieReviews(id);
            var reviewDetails = new List<ReviewMovieResponseModel>();
            foreach (var review in reviews)
            {
                reviewDetails.Add(new ReviewMovieResponseModel
                {
                    UserId = review.UserId,
                    MovieId = review.MovieId,
                    Rating = review.Rating,
                    ReviewText = review.ReviewText
                });
            }
            return reviewDetails;
        }

        public async Task< IEnumerable<MovieCardResponseModel>> GetTop25GrossingMovies()
        {
            var movies = await _movieRepository.GetTopRevenueMovies();
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

        public async Task<IEnumerable<MovieRatingResponseModel>> GetTopRatedMovies()
        {
            var movies = await _movieRepository.GetTopRatedMovies();

            var movieResponse = new List<MovieRatingResponseModel>();
            foreach (var movie in movies)
            {
                movieResponse.Add(new MovieRatingResponseModel
                {
                    Id = movie.Id,
                    PosterUrl = movie.PosterUrl,
                    Title = movie.Title,
                    ReleaseDate = movie.ReleaseDate,
                    Rating = movie.Rating
                });
            }
            return movieResponse;
        }
    }
}