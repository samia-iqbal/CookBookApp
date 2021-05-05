using CookBookApp.Data;
using CookBookApp.Interfaces;
using CookBookApp.Models;

namespace CookBookApp.Repositories
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
