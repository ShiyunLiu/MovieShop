using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieShop.Core.Entities;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MovieShop.Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Movie>> GetTopRatedMovies()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetTopRevenueMovies()
        {
            return await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(25).ToListAsync();
        }

        public override async Task<Movie> GetByIdAsync(int id)
        {
            return await _dbContext.Movies.Include(m => m.MovieCasts).ThenInclude(m => m.Cast).Include(m => m.Genres).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Review>> GetMovieReviews(int id)
        {
            var reviews = await _dbContext.Reviews.Where(r => r.MovieId == id).Include(r => r.User)
                                          .Select(r => new Review
                                          {
                                              UserId = r.UserId,
                                              Rating = r.Rating,
                                              MovieId = r.MovieId,
                                              ReviewText = r.ReviewText,
                                          }).ToListAsync();
            return reviews;
        }

        public async Task<IEnumerable<Purchase>> GetMoviePurchases(int id)
        {
            var purchases = await _dbContext.Purchases.Where(r => r.UserId == id).Include(r => r.Movie)
                .Select(r => new Purchase
                {
                    UserId = r.UserId,
                    MovieId = r.MovieId,
                    PurchaseNumber = r.PurchaseNumber,
                    TotalPrice = r.TotalPrice,
                    PurchaseDateTime = r.PurchaseDateTime
                }).ToListAsync();
            return purchases;
        }
    }
}
