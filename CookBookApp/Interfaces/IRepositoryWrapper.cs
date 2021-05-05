using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookApp.Interfaces
{
    public interface IRepositoryWrapper
    {
        IRecipeRepository Recipes { get; }

        IReviewRepository Reviews { get; }

        void Save();


    }
}
