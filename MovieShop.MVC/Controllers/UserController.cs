using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.Models.Request;
using MovieShop.Core.ServiceInterfaces;
using MovieShop.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IUserService _userService;

        public UserController(IUserService userService, IMovieService movieService)
        {
            _userService = userService;
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> BuyMovie(int id)
        {
            var movie = await _movieService.GetMovieById(id);
            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> BuyMovie(PurchaseRequestModel purchase)
        {
            await _userService.PurchaseMovie(purchase);
            return Ok();
        }
        // call this method when user clicks on Buy Movie in Movie details page
        // Filters,

       //[HttpGet]
       //[Authorize]
       // public async Task<IActionResult> BuyMovie(int id)
       // {
       //     var movie = await _movieService.GetMovieById(id);
       //     // call uerService to save the movie that will call repository, that will save in Purchase Table
       //     return View();
       // }

    }
}
