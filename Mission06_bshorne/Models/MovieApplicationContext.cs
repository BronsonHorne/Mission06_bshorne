using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_bshorne.Models
{
    public class MovieApplicationContext :DbContext
    {
        //Constructor
        public MovieApplicationContext(DbContextOptions<MovieApplicationContext> options) : base(options)
        {
            //Leave blank for now
        }
        public DbSet<ApplicationResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        //Seed Data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                    new Category { CategoryID = 1, CategoryName = "Action"},
                    new Category { CategoryID = 2, CategoryName = "Adventure" },
                    new Category { CategoryID = 3, CategoryName = "Comedy" },
                    new Category { CategoryID = 4, CategoryName = "Drama" },
                    new Category { CategoryID = 5, CategoryName = "Fantasy" },
                    new Category { CategoryID = 6, CategoryName = "Horror" },
                    new Category { CategoryID = 7, CategoryName = "Musical" },
                    new Category { CategoryID = 8, CategoryName = "Mystery" },
                    new Category { CategoryID = 9, CategoryName = "Romance" },
                    new Category { CategoryID = 10, CategoryName = "Science Fiction" },
                    new Category { CategoryID = 11, CategoryName = "Thriller" }
                );

            mb.Entity<ApplicationResponse>().HasData(

                new ApplicationResponse
                {
                    ApplicationId = 1,
                    CategoryID = 1,
                    Title = "The Accountant",
                    Year = 2016,
                    Director = "Gavin O'Connor",
                    Rating = "R",
                    Edited = true,
                    Lent = null,
                    Notes = "Was an amazing movie"
                },
                new ApplicationResponse
                {
                    ApplicationId = 2,
                    CategoryID = 1,
                    Title = "Inception",
                    Year = 2010,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    Lent = null,
                    Notes = "Was an amazing movie"
                },
                new ApplicationResponse
                {
                    ApplicationId = 3,
                    CategoryID = 1,
                    Title = "Deadpool",
                    Year = 2016,
                    Director = "Tim Miller",
                    Rating = "R",
                    Edited = true,
                    Lent = null,
                    Notes = "Was an amazing movie"
                }
            );
        }
    }
}
