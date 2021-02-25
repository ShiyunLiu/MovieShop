using MovieShop.Core.Entities;
using MovieShop.Core.Exceptions;
using MovieShop.Core.Models;
using MovieShop.Core.Models.Request;
using MovieShop.Core.Models.Response;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptoService _cryptoService;
        private readonly IAsyncRepository<Review> _reviewRepository;
        private readonly ICurrentLogedInUser _currentLogedInUser;
        public UserService(IUserRepository userRepository, ICryptoService cryptoService, IAsyncRepository<Review> reviewRepository, ICurrentLogedInUser currentLogedInUser)
        {
            _userRepository = userRepository;
            _cryptoService = cryptoService;
            _reviewRepository = reviewRepository;
            _currentLogedInUser = currentLogedInUser;
        }

        public async Task AddMovieReview(ReviewRequestModel reviewRequest)
        {
            var movieReview = new Review
            {
                UserId = reviewRequest.UserId,
                MovieId = reviewRequest.MovieId,
                Rating = reviewRequest.Rating,
                ReviewText = reviewRequest.ReviewText
            };
            await _reviewRepository.AddAsync(movieReview);
        }

        public async Task<IEnumerable<ReviewMovieResponseModel>> GetAllReviewsByUser(int id)
        {
            var reviews = await _reviewRepository.ListAsync(r => r.UserId == id);
            var response = new List<ReviewMovieResponseModel>();
            foreach (var movie in reviews)
            {
                response.Add(new ReviewMovieResponseModel
                {
                    UserId = movie.UserId,
                    MovieId = movie.MovieId,
                    Rating = movie.Rating,
                    ReviewText = movie.ReviewText
                });
            }
            return response;
        }

        public async Task<UserRegisterResponseModel> GetUserDetails(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            var response = new UserRegisterResponseModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            return response;
        }

        public async Task<bool> PurchaseMovie(PurchaseRequestModel purchaseRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterUser(UserRegisterRequestModel userRegisterRequestModel)
        {
            // we need to check whether that email exists or not
            var dbUser = await _userRepository.GetUserByEmail(userRegisterRequestModel.Email);
            if (dbUser != null)
            {
                throw new ConflictException("Email already exists");
            }

            // first generate Salt

            var salt = _cryptoService.GenerateRandomSalt();
            var hashedPassword = _cryptoService.HashPassword(userRegisterRequestModel.Password, salt);
            // hash the password with salt and save the salt and hashed password to the Database

            var user = new User
            {
                Email = userRegisterRequestModel.Email,
                Salt = salt,
                HashedPassword = hashedPassword,
                FirstName = userRegisterRequestModel.FirstName,
                LastName = userRegisterRequestModel.LastName,
                DateOfBirth = userRegisterRequestModel.DateOfBirth
            };

            var createdUser = await _userRepository.AddAsync(user);

            if (createdUser != null && createdUser.Id > 0)
            {
                return true;
            }
            return false;
        }


        public async Task<LoginResponseModel> ValidateUser(LoginRequestModel loginRequestModel)
        {
            var dbUser = await _userRepository.GetUserByEmail(loginRequestModel.Email);

            if (dbUser == null)
            {
                return null;
            }

            var hashedPassword = _cryptoService.HashPassword(loginRequestModel.Password, dbUser.Salt);

            // get the roles of that user and 

            if (hashedPassword == dbUser.HashedPassword)
            {
                // User has entered correct password

                var loginResponse = new LoginResponseModel
                {
                    Id = dbUser.Id,
                    Email = dbUser.Email,
                    FirstName = dbUser.FirstName,
                    LastName = dbUser.LastName,
                    DateOfBirth = dbUser.DateOfBirth,
                    Roles = null

                };

                return loginResponse;
            }

            return null;

        }
    }
}
