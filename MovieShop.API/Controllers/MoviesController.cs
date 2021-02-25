using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")] //attribute routing
    [ApiController]
    public class MoviesController : ControllerBase //inherits directly from ControllerBase instead of Controller since we don't need to return views in API Controllers
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Route("toprevenue")]
        public async Task<IActionResult> GetTopRevenueMovies()
        {
            var movies = await _movieService.GetTop25GrossingMovies();

            if (!movies.Any())
            {
                return NotFound("We did not find any movies");
            }
            return Ok(movies); // return JSON data by serialization

            // System.Text.Json in .NET Core 3
            // previous versions of .Net 1,2 and previous older .NET Framework Newtonsoft, 3rdy party library
            // Serialization , convert your C# objects in t JSON objetcs
            // De-Serialization, convert json objects to C#
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _movieService.GetMovieById(id);
            if (movie != null)
            {
                return Ok(movie);
            }
            return NotFound("No Movies Found");
        }

        [HttpGet]
        [Route("genre/{genreId:int}")]
        public async Task<IActionResult> GetMoviesByGenre(int genreId)
        {
            var movies = await _movieService.GetMoviesByGenre(genreId);
            if (movies != null)
            {
                return Ok(movies);
            }
            return NotFound("No Movies Found");
        }

        [HttpGet]
        [Route("toprated")]
        public async Task<IActionResult> GetTopRatedMovies()
        {
            var movies = await _movieService.GetTopRatedMovies();
            return Ok(movies);
        }

        [HttpGet]
        [Route("{id}/reviews")]
        public async Task<IActionResult> GetMovieReviews(int id)
        {
            var reviews = await _movieService.GetReviewsForMovie(id);
            return Ok(reviews);
        }
    }
}
