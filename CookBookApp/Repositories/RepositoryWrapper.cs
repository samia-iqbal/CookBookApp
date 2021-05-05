using CookBookApp.Data;
using CookBookApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookApp.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        ApplicationDbContext _repoContext;
      public RepositoryWrapper(ApplicationDbContext repoContext)
        {
            _repoContext = repoContext;
        }
        IRecipeRepository _recipes;
        IReviewRepository _reviews;

        public IRecipeRepository Recipes
        {
            get
            {
                if (_recipes == null)
                {
                    _recipes = new RecipeRepository(_repoContext);

                }
                return _recipes;
            }
        }

        public IReviewRepository Reviews
        {
            get
            {
                if (_reviews == null)
                {
                    _reviews = new ReviewRepository(_repoContext);

                }
                return _reviews;
            }
        }
       

        void IRepositoryWrapper.Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
