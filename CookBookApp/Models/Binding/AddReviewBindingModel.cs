using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookApp.Models.Binding
{
    public class AddReviewBindingModel
    {
        public int Rating { get; set; }
        public string Description { get; set; }
        public DateTime createdAt { get; set; }
        public int RecipeID { get; set; }

        public virtual Recipe Recipe { get; set; }
    }

}
