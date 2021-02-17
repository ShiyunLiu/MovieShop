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

    }
}
