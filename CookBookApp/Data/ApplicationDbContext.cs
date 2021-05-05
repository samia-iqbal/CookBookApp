using CookBookApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookApp.Data
{
    public class ApplicationDbContext : DbContext //install the package microsft.entityframework
    {
       

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) //pick up the propetities and passing it to the parent class constructor 
        { }
            public DbSet<Recipe> Recipes { get; set; } //creating the headings of the table 
        public DbSet<Review> Reviews { get; set; }




    }
}
