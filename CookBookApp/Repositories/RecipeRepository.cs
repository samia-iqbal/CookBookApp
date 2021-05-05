using CookBookApp.Data;
using CookBookApp.Interfaces;
using CookBookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookApp.Repositories
{
    public class RecipeRepository: Repository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
