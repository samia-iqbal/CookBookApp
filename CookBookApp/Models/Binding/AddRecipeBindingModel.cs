using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookApp.Models.Binding
{
    public class AddRecipeBindingModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
       
        public string Description { get; set; }
        public int NoServing { get; set; }
        public string PrepTime { get; set; }
        public string Ingredient { get; set; }
        public string Method { get; set; }
        public string ImageURL { get; set; }
        public virtual List<Review> Reviews { get; set; }
    }
}
