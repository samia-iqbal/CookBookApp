using CookBookApp.Data;
using CookBookApp.Interfaces;
using CookBookApp.Models;
using CookBookApp.Models.Binding;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookApp.Controllers
{
    [Route("[Controller]")]
    public class RecipesController : Controller
    {
        private IRepositoryWrapper repository;
        //private readonly ApplicationDbContext dbContext;
        public RecipesController(IRepositoryWrapper repositoryWrapper)
        {
            repository = repositoryWrapper;
        }

        //READ
        [Route("")]
        public IActionResult Index()
        {
            var viewAllRecipes = repository.Recipes.FindAll();
            //var viewAllRecipes = dbContext.Recipes.ToList();
            return View(viewAllRecipes);
        }
        [Route("details/{id:int}")]
        public IActionResult ViewRecipes(int id)
        {
            var recipeId = repository.Recipes.FindByCondition(r => r.ID == id).FirstOrDefault();
            //var recipeId = dbContext.Recipes.FirstOrDefault(r => r.ID == id);
            return View(recipeId);
        }

        //CREATE
        [Route("create")]
        public IActionResult CreateRecipe()
        {
            return View();
        }
        [HttpPost("create")]
        public IActionResult CreateRecipe(AddRecipeBindingModel bindingModel)
        {
            var createRecipe = new Recipe
            {
                Name = bindingModel.Name,
                Description = bindingModel.Description,
                NoServing = bindingModel.NoServing,
                PrepTime = bindingModel.PrepTime,
                Ingredient = bindingModel.Ingredient,
                Method = bindingModel.Method,
                ImageURL = bindingModel.ImageURL
            };
            //dbContext.Recipes.Add(createRecipe);
            repository.Recipes.Create(createRecipe);
            repository.Save();
            //dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        
        //UPDATE
        [Route("update/{id:int}")]
        public IActionResult UpdateRecipe(int id)
        {
            //var recipeId = dbContext.Recipes.FirstOrDefault(r => r.ID == id);
            var recipeId = repository.Recipes.FindByCondition(r => r.ID == id).FirstOrDefault();

            return View(recipeId);
        }
        [HttpPost]
        [Route("update/{id:int}")]
        public IActionResult UpdateRecipe(Recipe recipe, int id)
        {

            //var updateRecipe = dbContext.Recipes.FirstOrDefault(r => r.ID == id);
            //var updateRecipe = repository.Recipes.FindByCondition(r => r.ID.Equals(id)).FirstOrDefault();
            //updateRecipe.Name = recipe.Name;
            //updateRecipe.Description = recipe.Description;
            //updateRecipe.NoServing = recipe.NoServing;
            //updateRecipe.PrepTime = recipe.PrepTime;
            //updateRecipe.Ingredient = recipe.Ingredient;
            //updateRecipe.Method = recipe.Method;
            //updateRecipe.ImageURL = recipe.ImageURL;
            //dbContext.SaveChanges();
            repository.Recipes.Update(recipe);
            repository.Save();
            return RedirectToAction("Index");
        }
        //DELETE
        [Route("delete/{id:int}")]
        public IActionResult Delete(int id)
        {

            //var deleteRecipe = dbContext.Recipes.FirstOrDefault(r => r.ID == id);
            var deleteRecipe = repository.Recipes.FindByCondition(r => r.ID == id).FirstOrDefault();
            //var deleteReview = dbContext.Reviews.Where(r => r.Recipe.ID == id);
            var deleteReview = repository.Reviews.FindByCondition(r => r.Recipe.ID == id);
            foreach (var review in deleteReview)
            {
                //dbContext.Reviews.Remove(review);
                repository.Reviews.Delete(review);
            }
            //dbContext.SaveChanges();
            repository.Save();
            //dbContext.Recipes.Remove(deleteRecipe);
            repository.Recipes.Delete(deleteRecipe);
            //dbContext.SaveChanges();
            repository.Save();
            return RedirectToAction("Index");
        }
    }
}
