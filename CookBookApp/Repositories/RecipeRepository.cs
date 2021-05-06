using CookBookApp.Data;
using CookBookApp.Interfaces;
using CookBookApp.Models;

namespace CookBookApp.Repositories
{
    public class RecipeRepository: Repository<Recipe>,IRecipeRepository
    {
        public RecipeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
