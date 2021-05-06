using CookBookApp.Controllers;
using CookBookApp.Interfaces;
using CookBookApp.Models;
using CookBookApp.Models.Binding;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CookBookAppTest
{
    public class RecipeTest
    {
        private RecipesController recipesController;
      
        private Mock<IRepositoryWrapper> mockRepo;
        //private AddRecipeBindingModel addRecipe;


        public RecipeTest()
        {
            mockRepo = new Mock<IRepositoryWrapper>();
            recipesController = new RecipesController(mockRepo.Object);

            
        }

        [Fact]
        public void GetAllRecipes_Test()
        {
            //Arrange
            Moq.Language.Flow.IReturnsResult<IRepositoryWrapper> returnsResult = mockRepo.Setup(repo => repo.Recipes.FindAll()).Returns(GetRecipes);
            //Act
            var controllerActionResult = recipesController.Index();
            //Assert
            Assert.NotNull(controllerActionResult);



        }



        private IEnumerable<Recipe> GetRecipes()
        {
            var recipes = new List<Recipe>
       {
           new Recipe(){ID = 1,
               Name = "Sevenup",
               Description = "yummy", NoServing = 2,
               PrepTime = "10 minute", Ingredient = "onions", Method = "mix it", ImageURL ="https://www.megaretailer.co.uk/media/catalog/product/cache/a6f4aec1db93cb13677a62a0babd5631/1/7/17UP3000-16_08_2019_10_58_53_14.jpg" },
                new  Recipe(){ID = 2,
               Name = "juice",
               Description = "eded", NoServing = 10,
               PrepTime = "20 minute", Ingredient = "lettuce", Method = "mixrdgdg it", ImageURL ="https://www.megaretailer.co.uk/media/catalog/product/cache/a6f4aec1db93cb13677a62a0babd5631/1/7/17UP3000-16_08_2019_10_58_53_14.jpg" }
                };
               return recipes;
            
        }
        private Recipe GetRecipe()
        {
            return GetRecipes().ToList()[0];
        }
    }
}
