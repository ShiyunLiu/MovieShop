using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieShop.Infrastructure.Services;
using MovieShop.Core.ServiceInterfaces;
//using MovieShop.Core.Entities;
//using MovieShop.Core.RepositoryInterfaces;
//using MovieShop.Infrastructure.Repositories;

namespace MovieShop.MVC.Controllers
{
    public class MoviesController : Controller
    {

        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            // call the Movie service that will call Movie Repository
            var movieDetails = await _movieService.GetMovieById(id);
            return View(movieDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Reviews(int id)
        {
            var movieReviews = await _movieService.GetReviewsForMovie(id);
            return View(movieReviews);
        }
    }
}
