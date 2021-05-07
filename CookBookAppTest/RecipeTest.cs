using CookBookApp.Controllers;
using CookBookApp.Interfaces;
using CookBookApp.Models;
using CookBookApp.Models.Binding;
using Microsoft.AspNetCore.Mvc;
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
        private ReviewsController reviewsController;

        private readonly Mock<IRepositoryWrapper> mockRepo;
        private readonly AddRecipeBindingModel addRecipe;
        private readonly AddReviewBindingModel addReview;

        public RecipeTest()
        {
            mockRepo = new Mock<IRepositoryWrapper>();
            recipesController = new RecipesController(mockRepo.Object);
            reviewsController = new ReviewsController(mockRepo.Object);
            addRecipe = new AddRecipeBindingModel() { };
            addReview = new AddReviewBindingModel() { };

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
        [Fact]
        public void GetAllReviews_Test()
        {
            //Arrange
            Moq.Language.Flow.IReturnsResult<IRepositoryWrapper> returnsResult = mockRepo.Setup(repo => repo.Reviews.FindAll()).Returns(GetReviews);
            //Act
            var controllerActionResult = reviewsController.Index();
        //Assert
        Assert.NotNull(controllerActionResult);

        }
        private IEnumerable<Review> GetReviews()
           {
            var reviews = new List<Review>
          {
           new Review(){ID = 1,
          Rating = 4, Description = "amazing", createdAt = DateTime.Parse("2020-12-06 00:12:11") },
                new Review() { ID = 2,
               Rating = 5, Description = "amazing", createdAt = DateTime.Parse("2020-12-06 00:12:11") }
                };
            return reviews;
           
           }
        private Review GetReview()
        {
            return GetReviews().ToList()[0];
        }
        [Fact]
        private void AddRecipe_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Recipes.FindByCondition(r => r.ID == It.IsAny<int>())).Returns(GetRecipes());
            //Act
            var controllerActionResult = new RecipesController(mockRepo.Object).CreateRecipe(addRecipe);
            //Assert
            Assert.NotNull(controllerActionResult);
            Assert.IsType<RedirectToActionResult>(controllerActionResult);
          
        }
        [Fact]
        private void AddReview_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Reviews.FindByCondition(r => r.ID == It.IsAny<int>())).Returns(GetReviews());
            //Act
            var controllerActionResult = new ReviewsController(mockRepo.Object).CreateReview(addReview,It.IsAny<int>());
            //Assert
            Assert.NotNull(controllerActionResult);
            Assert.IsType<RedirectToActionResult>(controllerActionResult);

        }
        [Fact]
        public void DeleteRecipe_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Recipes.FindByCondition(r => r.ID == It.IsAny<int>())).Returns(GetRecipes());
            mockRepo.Setup(repo => repo.Reviews.FindByCondition(r => r.ID == It.IsAny<int>())).Returns(GetReviews());
            mockRepo.Setup(repo => repo.Recipes.Delete(GetRecipe()));
            //Act
            var controllerActionResult = recipesController.Delete(It.IsAny<int>());
            //Assert
            Assert.NotNull(controllerActionResult);
        }
        [Fact]
        public void EditRecipe_Test()
        {
            //Arrange 
            mockRepo.Setup(repo => repo.Recipes.FindByCondition(r => r.ID == It.IsAny<int>())).Returns(GetRecipes());
            mockRepo.Setup(repo => repo.Recipes.Update(GetRecipe()));
            var controllerActionResult = recipesController.UpdateRecipe(It.IsAny<int>());
            Assert.NotNull(controllerActionResult);


        }

        [Fact]
        public void EditRecipe_Test_WithAction()
        {
            //Arrange 
            mockRepo.Setup(repo => repo.Recipes.FindByCondition(r => r.ID == It.IsAny<int>())).Returns(GetRecipes());
            mockRepo.Setup(repo => repo.Recipes.Update(GetRecipe()));
            var controllerActionResult = recipesController.UpdateRecipe(It.IsAny<int>());
            Assert.NotNull(controllerActionResult);


        }

      
       
    }
}
