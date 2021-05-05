using CookBookApp.Data;
using CookBookApp.Models;
using CookBookApp.Models.Binding;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookApp.Controllers
{
    [Route("[Controller]/[Action]")]
    public class ReviewsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public ReviewsController(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }
        //READ
        [Route("")]
        public IActionResult Index()
        {
            var viewAllReviews = dbContext.Reviews.ToList();
            return View(viewAllReviews);
        }
        [Route("details/{id:int}")]
        public IActionResult Details(int id)
        {
            var reviewId = dbContext.Reviews.FirstOrDefault(r => r.ID == id);
            return View(reviewId);
        }

        //Review Section
        //CREATE
        [Route("addreview/{recipeID:int}")]
        public IActionResult CreateReview(int recipeID)
        {
            var recipe = dbContext.Recipes.FirstOrDefault(r => r.ID == recipeID);
            ViewBag.RecipeName = recipe.Name;
            return View();
        }
        [HttpPost]
        [Route("addreview/{recipeID:int}")]
        public IActionResult CreateReview(AddReviewBindingModel bindingModel, int recipeID)
        {
            bindingModel.RecipeID = recipeID;
            var createReview = new Review
            {
                Rating = bindingModel.Rating,
                Description = bindingModel.Description,
                Recipe = dbContext.Recipes.FirstOrDefault(r => r.ID == recipeID),
                createdAt = DateTime.Now

            };
            dbContext.Reviews.Add(createReview);
            dbContext.SaveChanges();
            return RedirectToAction("ViewReviews", new { id = recipeID }); //directing to the viewreview page

        }
        [Route("{id:int}/reviews")]
        public IActionResult ViewReviews(int id)
        {
            var recipe = dbContext.Recipes.FirstOrDefault(r => r.ID == id);
            var reviews = dbContext.Reviews.Where(r => r.Recipe.ID == id).ToList();
            ViewBag.RecipeName = recipe.Name;
            return View(reviews);
        }

        ////UPDATE
        //[Route("update/{id:int}")]
        //public IActionResult Update(int id)
        //{
        //    var reviewId = dbContext.Reviews.FirstOrDefault(r => r.ID == id);
        //    return View(reviewId);
        //}
        //[HttpPost]
        //[Route("update/{id:int}")]
        //public IActionResult Update(Review review, int id)
        //{
        //    var updateReview = dbContext.Reviews.FirstOrDefault(r => r.ID == id);
        //    updateReview.Rating = review.Rating;
        //    updateReview.Description = review.Description;
        //    updateReview.createdAt = DateTime.Now;
        //    dbContext.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        //DELETE
        //[Route("delete/{id:int}")]
        //public IActionResult Delete(int id)
        //{
        //    var reviewToDelete = dbContext.Reviews.FirstOrDefault(r => r.Recipe.ID == id);
        //    dbContext.Reviews.Remove(reviewToDelete);
        //    dbContext.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}
