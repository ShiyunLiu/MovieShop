using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.Models.Request;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel requestModel)
        {
            // Model Binding
            // Form, it will look for input elements names and if those names match with our Action menthod model
            // properties
            // then it will automatically map that data

            // a control with name=EMAIL "abc@abc.com"
            // UserRegisterRequestModel => Email

            if (!ModelState.IsValid)
            {
                return View();
            }
            // only when every validaiton passes make sure you save to database
            // call our User Service to save to Db
            var createdUser = await _userService.RegisterUser(requestModel);
            if (createdUser)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
    }
}
